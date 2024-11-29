using PTCApp.Entities;
using PTCApp.Models;
using System.Reflection;

namespace PTCApp.ManagerClasses
{
    public class SecurityManager
    {
        public SecurityManager(PtcDbContext context, UserAuthBase auth)
        {
            _DbContext = context;
            _auth = auth;
        }

        private PtcDbContext? _DbContext = null;
        private UserAuthBase? _auth = null;

        protected List<UserClaim> GetUserClaims(Guid userId)
        {
            List<UserClaim> list = new List<UserClaim>();
            try
            {
                if (_DbContext != null)
                {
                    list = _DbContext.UserClaims.Where(uc => uc.UserId == userId).ToList();
                }
                else
                {
                    throw new Exception("Database context is null");
                }
            }
            catch (Exception)
            {
                throw new Exception(
                    "Exception trying to retrieve User Claims from the Database");
            }
            return list;
        }

        protected UserAuthBase BuildUserAuthObject(Guid userId, string userName)
        {
            List<UserClaim> claims = new List<UserClaim>();
            Type _authType = _auth.GetType();

            // Set User Properties
            _auth.UserId = userId;
            _auth.UserName = userName;
            _auth.IsAuthenticated = true;

            // Get all claims for this user
            claims = GetUserClaims(userId);

            //Loop through all claims and set them in the User object
            foreach (UserClaim claim in claims)
            {
                try
                {
                    // User reflection to set property
                    PropertyInfo? property = _authType.GetProperty(claim.ClaimType);
                    if (property != null)
                    {
                        property.SetValue(_auth, Convert.ToBoolean(claim.ClaimValue), null);
                    }
                }
                catch
                {

                }
            }

            return _auth!;

        }

        public UserAuthBase ValidateUser(string userName, string password)
        {
            List<UserBase> list = new List<UserBase>();

            try
            {
                if (_DbContext != null)
                {
                    list = _DbContext.Users.Where(
                        u => u.UserName.ToLower() == userName.ToLower() &&
                        u.Password == password).ToList();

                    if (list.Count > 0)
                    {
                        UserBase user = list[0];
                        _auth = BuildUserAuthObject(list[0].UserId, userName);
                    }
                }
                else
                {
                    throw new Exception("Database context is null");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Exception trying to validate user", ex);
            }

            return _auth!;
        }
    }
}

namespace Models
{


    public enum userRole
    {
        Employee,Manager
    }

    public class User
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public userRole userRole { get; set; }

        // for retrieving objects from database
        public User(
            int userID,
            string userName,
            string password,
            userRole userRole)
        {
            this.userID = userID;
            this.userName = userName;
            this.password = password;
            this.userRole = userRole;
        }

        // for putting objects into database
        public User(
            string userName,
            string password,
            userRole userRole)
        {
            this.userName = userName;
            this.password = password;
            this.userRole = (userRole) userRole;
        }

        // for getting user by userName
        public User(
            string userName,
            string password,
            int userRole)
        {
            this.userName = userName;
            this.password = password;
            this.userRole = (userRole) userRole;
        }

        // for logging in
        public User(
            string userName,
            string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public User(){}

        public string userRoleToString(userRole userRoleNotString)
        {
            if(userRoleNotString == userRole.Employee)
            {
                return "employee";
            }
            else { return "manager"; }
        }

        public int userRoleToInt(string userRoleNotInt)
        {
           if(userRoleNotInt == "employee")
            {
                return 0;
            }
            else { return 1; }
        }        

        public override string ToString()
        {
            return $"userID: " + this.userID +
            ", userName: " + this.userName +
            ", password: " + this.password +
            ", userRole: " + this.userRole;
        }

    }
}
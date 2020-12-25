using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteManagerPanel.Framework.RoleEnums
{
    public class Enum
    {
        public enum RoleGroup
        {
            Employee = 1,
            Admin = 2
        }
        public enum AdminRole
        {
            ShowSite = 1,
            CanChangeSite = 2,
            ShowDefinition = 4,
            CanChangeDefinition = 8,
            ShowField = 16,
            CanChangeField = 32,
        }
        public enum EmployeeRole
        {
            GetEmployees = 1,
            CanChangeEmployee = 2
        }
    }
}

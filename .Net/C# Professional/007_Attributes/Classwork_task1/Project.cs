using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Classwork_task1
{
    class Project
    {
        [AccessLevel(AccessLevels.Director)]
        string financesInfo;    // Financial information of the project - Director level

        [AccessLevelAttribute(AccessLevels.Manager)]
        string customerInfo;    // Customer of the project - Manager level

        [AccessLevelAttribute(AccessLevels.Programmer)]
        string codeInfo;        // The project code - Programmer level



        public Project(string financesInfo, string customerInfo, string codeInfo)
        {
            this.financesInfo = financesInfo;
            this.customerInfo = customerInfo;
            this.codeInfo = codeInfo;

        }

        public (bool success, string info) GetFinancesInfo(Employee employee)
        {
            AccessLevels employeeAccessLevel = employee.AccessLevel;
            AccessLevels infoAccessLevel = (GetType().GetField(nameof(financesInfo), BindingFlags.NonPublic | BindingFlags.Instance).GetCustomAttributes(false).First() as AccessLevelAttribute).AccessLevel;

            if (employeeAccessLevel >= infoAccessLevel)
                return (true, financesInfo);
            else
                return (false, $"The user {employee.Position} does not have access to the information!");
        }
        public (bool success, string info) GetCustomerInfo(Employee employee)
        {
            AccessLevels employeeAccessLevel = employee.AccessLevel;
            AccessLevels infoAccessLevel = (GetType().GetField(nameof(customerInfo), BindingFlags.NonPublic | BindingFlags.Instance).GetCustomAttributes(false).First() as AccessLevelAttribute).AccessLevel;

            if (employeeAccessLevel >= infoAccessLevel)
                return (true, customerInfo);
            else
                return (false, $"The user {employee.Position} does not have access to the information!");
        }
        public (bool success, string info) GetCodeInfo(Employee employee)
        {
            AccessLevels employeeAccessLevel = employee.AccessLevel;
            AccessLevels infoAccessLevel = (GetType().GetField(nameof(codeInfo), BindingFlags.NonPublic | BindingFlags.Instance).GetCustomAttributes(false).First() as AccessLevelAttribute).AccessLevel;

            if (employeeAccessLevel >= infoAccessLevel)
                return (true, codeInfo);
            else
                return (false, $"The user {employee.Position} does not have access to the information!");
        }


    }
}

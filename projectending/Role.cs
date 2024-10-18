using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectending
{
    public class Role
    {
        private string roleID;
        private string rolename;
        private string permission;
        public bool checkexist = false;
  
        public Role(string roleID, string rolename, string permission)
        {
            this.roleID = roleID;
            this.rolename = rolename;
            this.permission = permission;
        }

        public string checkroleID(List<Employee> employee, List<Role>role)
        {
            Console.Write("Nhap ma chuc vu ");
            string x = Console.ReadLine();
            foreach (Employee emp in employee)
            {


                foreach (Role role1 in role)
                {


                    if (emp.EmployeeID() == role1.roleID)
                    {
                        return role1.rolename;
                    }
                }
            }
            return "Mã chức vụ không tồn tại";
            
        }

        public void addpermission() 
        {

        }

        public void removepermission() 
        {

        }

        public void Updatepermission()
        {

        }

    }
}

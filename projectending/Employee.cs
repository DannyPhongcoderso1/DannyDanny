using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectending
{
    public class Employee
    {
        private string name;
        private string employeeID;
        private string roleID;
        private string departmentID;
        private decimal salary;
        private string dateofhire;
        private int paidleave;

     
        public string EmployeeID() { return employeeID; }
      
        public string RoleID() { return roleID; }
       
        public string DepartmentID() { return departmentID; }
        
        public decimal Salary() { return salary; }
        
        public string DateOfHire() {return dateofhire;}
    


        public Employee(string name,string employeeID, string roleID, string departmentID, decimal salary, string dateofhire)
        {
            this.employeeID = employeeID;
            this.roleID = roleID;
            this.departmentID = departmentID;
            this.salary = salary;
            this.dateofhire = dateofhire;    

        }
        public void Absent(List<Employee> employees)
        {
            
            Console.WriteLine("Nhap ma nhan vien: ");
            string absentemployeeID = Console.ReadLine();
            foreach (Employee employee in employees)
            {
                if(employee.EmployeeID() == absentemployeeID)
                {
                    employee.paidleave++;
                }    
            }
        } 

        public int numAbsent(List<Employee> employees, string employeeID)
        {
            foreach (Employee employee in employees)

            {
                if(employee.EmployeeID() ==  employeeID)
                    return employee.paidleave;
            }
            return 0;
        }
        

        public void Add(List<Employee> employee)
        {
            Console.Write("nhap ten: ");
            name = Console.ReadLine();
            Console.Write("nhap ma cong nhan: ");
            employeeID = Console.ReadLine();
            Console.Write("nhap ma chuc vu: ");
            roleID = Console.ReadLine();
            Console.Write("nhap ma phong ban: ");
            departmentID = Console.ReadLine();
            Console.Write("nhap tien luong");
            salary = decimal.Parse(Console.ReadLine());
            Console.Write("Nhap ngay vao lam: ");
            dateofhire = Console.ReadLine();


            employee.Add(new Employee(name, employeeID, roleID, departmentID, salary, dateofhire));
        }

        public void Remove(List<Employee> employee)
        {
            Console.Write("Nhap ma nhan vien ban muon xoa: ");
            string employeeIDtodelete = Console.ReadLine();
            foreach(Employee emp in employee)
            {
                if(emp.employeeID == employeeIDtodelete)
                {
                    employee.Remove(emp);
                }
            }
        }

        public void Update(List<Employee> employee)
        {
            Console.Write("Nhap ma nhan vien ban muon chinh sua: ");
            string employeeIDtoupdate = Console.ReadLine();
            foreach (Employee emp in employee)
            {
                if(emp.employeeID == employeeIDtoupdate)
                {
                    Console.Write("Nhap vi tri ban muon sua: ");
                    int vitri = int.Parse(Console.ReadLine());
                    switch(vitri)
                    {
                        case 1:
                            {
                                Console.Write("nhap ten moi: ");
                                string tenmoi = Console.ReadLine();
                                emp.name = tenmoi;
                            }
                            break;
                        case 2:
                            {
                                Console.Write("nhap ma nhan vien moi: ");
                                string newemployeeid = Console.ReadLine();
                                emp.employeeID = newemployeeid;
                            }
                            break;
                        case 3:
                            {
                                Console.Write("nhap ma chuc vu moi: ");
                                string newroleid = Console.ReadLine();
                                emp.roleID = newroleid;
                            }
                            break;
                        case 4:
                            {
                                Console.Write("nhap ma phong ban moi: ");
                                string newdepartmentid = Console.ReadLine();
                                emp.departmentID = newdepartmentid;
                            }
                            break;
                        case 5:
                            {
                                Console.Write("nhap so tien luong moi: ");
                                decimal newsalary = decimal.Parse(Console.ReadLine());
                                emp.salary = newsalary;
                            }
                            break;

                        case 6:
                            {
                                Console.Write("nhap ngay vao lam moi");
                                string newdate = Console.ReadLine();
                                emp.dateofhire = newdate;
                            }
                            break;
                    }
                }    
            }    
        }
    }
}

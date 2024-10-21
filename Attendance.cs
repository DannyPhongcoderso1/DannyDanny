using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectending
{
    public class Attendance
    {
        private int attendanceID;
        private string employeeID;
        private TimeOnly checkintime;
        private TimeOnly checkouttime;
        private string status;
        
        private TimeOnly dafaulttimein = new TimeOnly(9,0);
        private TimeOnly defaulttimeout = new TimeOnly(17,0);
        private bool checkin = false;
        private bool checkout = false;
        private TimeSpan ottime;
        private DateTime date;
        private int workingday;

   

        public static List<Attendance> Attendances = new List<Attendance>();
        Dictionary<string, List<Attendance>> attendancesrecord = new Dictionary<string, List<Attendance>>();

  

        public Attendance(string employeeID, DateTime date, TimeOnly checkintime, bool checkin, string status, TimeOnly checkoutime, bool checkout, TimeSpan ottime)
        {
            this.employeeID = employeeID;
            this.date = date;
            this.checkintime = checkintime;
            this.checkin = checkin;
            this.status = status;
            this.checkout = checkout;
            this.checkout = checkout;
            this.ottime = ottime;
            
        }

        public void TimeIn(TimeOnly checkintime)
        {
            if(checkintime >= defaulttimeout && checkintime <= new TimeOnly(9,15)) 
            {
                checkin = true;
                status = "normal";
            }
            else if(checkintime > new TimeOnly(9,15))  
            {
                checkin = true;
                status = "late";
            }

    
        }

        public void TimeOut(TimeOnly checkouttime)
        {
            if(checkouttime >= defaulttimeout && checkouttime <= new TimeOnly(18,0)) 
            {
                checkout = true;
                
            }
            else if (checkouttime > new TimeOnly(19,0))
            {
                TimeSpan newottime;
                checkout = true ;
                newottime = checkouttime - new TimeOnly(19,0);
                ottime += newottime;
                
            }    
     
        }

        public int Countday(string employeeID) 
        {
         
            if (attendancesrecord.ContainsKey(employeeID))
            {
                List<Attendance> attendances = attendancesrecord[employeeID];
                
                foreach(Attendance attendance in attendances)
                {
                    if(attendance.checkout && attendance.checkin)
                    {
                        attendance.workingday++;
                    }    
                }
            }
            return workingday;
            
        }

    //tạo bảng điểm danh mới mỗi ngày cho từng người 
        public void createdailyrecord(List<Employee> employees)
        {
            DateTime today = DateTime.Today;
            
            foreach (Employee employee in employees)
            {
                List<Attendance> attendances = attendancesrecord[employee.EmployeeID()];

                bool hasrecord = false;

                for (int i = 0; i < attendances.Count; i++)
                {
                    if (attendances[i].date.Date == today )
                    {
                        hasrecord = true;
                        break;
                    }    
                } 
                
                if (!hasrecord)
                {
                    Attendance attendance = new Attendance(employee.EmployeeID(), date, TimeOnly.MinValue, false, "none", TimeOnly.MinValue, false, default);
                    attendance.checkintime = TimeOnly.MinValue;
                    attendance.checkouttime = TimeOnly.MinValue;

                    attendancesrecord[employee.EmployeeID()].Add(attendance);
                }    
            }
        }

        //update khi người dùng checkin và checkout
        public void Updaterecord(string employeeID)
        {
            List<Attendance> attendances = attendancesrecord[employeeID];
            DateTime today = DateTime.Today;
            foreach (Attendance attendance in attendances)
            {
                if(attendance.date== today)
                {
                    Console.WriteLine("chon 1. checkin 2.checkout: ");
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                attendance.checkintime = TimeOnly.FromDateTime(DateTime.Now);
                                attendance.TimeIn(attendance.checkintime);
                                attendance.checkin = true;
                                
                            }
                            break;
                        case 2:
                            {
                                attendance.checkouttime = TimeOnly.FromDateTime(DateTime.Now);
                                attendance.TimeOut(attendance.checkouttime);
                                attendance.checkout = true;
                            }
                            break;
                    }
                }    
            }    
           
        }

    }
}

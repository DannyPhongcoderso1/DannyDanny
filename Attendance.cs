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
            //private string employeeID;
            private TimeSpan checkintime;
            private TimeSpan checkouttime;
            private string status;

           
            private TimeSpan dafaulttimein = new TimeSpan(9,0,0);
            private TimeSpan defaulttimeout = new TimeSpan(17,0,0);
            private bool checkin = false;
            private bool checkout = false;
            private TimeSpan ottime;
            private DateTime date;
            private int workingday;

   

            //public static List<Attendance> Attendances = new List<Attendance>();
            Dictionary<string, List<Attendance>> attendancesrecord = new Dictionary<string, List<Attendance>>();

  

            public Attendance( DateTime date, TimeSpan checkintime, bool checkin, string status, TimeSpan checkoutime, bool checkout, TimeSpan ottime)
            {
                //this.employeeID = employeeID;
                this.date = date;
                this.checkintime = checkintime;
                this.checkin = checkin;
                this.status = status;
                this.checkout = checkout;
                this.checkout = checkout;
                this.ottime = ottime;
            
            }

            public void TimeIn(TimeSpan checkintime)
            {
                
                if(checkintime >= defaulttimeout && checkintime <= new TimeSpan(9,15,0)) 
                {
                    checkin = true;
                    status = "normal";
                }
                else if(checkintime > new TimeSpan(9,15,0))  
                {
                    checkin = true;
                    status = "late";
                }

    
            }

            public void TimeOut(TimeSpan checkouttime)
            {
                if(checkouttime >= defaulttimeout && checkouttime <= new TimeSpan(18,0,0)) 
                {
                    checkout = true;
                
                }
                else if (checkouttime > new TimeSpan(18,0, 0))
                {
                    TimeSpan newottime;
                    checkout = true ;
                    newottime = checkouttime - new TimeSpan(18,0, 0);
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
                        Attendance attendance = new Attendance( date, TimeSpan.MinValue, false, "none", TimeSpan.MinValue, false, default);
                        attendance.checkintime = TimeSpan.MinValue;
                        attendance.checkouttime = TimeSpan.MinValue;

                        attendancesrecord[employee.EmployeeID()].Add(attendance);
                    }    
                }
            }

            //update khi người dùng checkin và checkout
            //kiểm tra mã nhân viên khi người dùng nhập vào 
            public void Updaterecord(string employeeID)
            {

                List<Attendance> attendances = attendancesrecord[employeeID];
                DateTime today = DateTime.Today;
                DateTime now = DateTime.Now;
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
                                    attendance.checkintime = now.TimeOfDay;
                                    attendance.TimeIn(attendance.checkintime);
                                    attendance.checkin = true;
                                
                                }
                                break;
                            case 2:
                                {
                                    attendance.checkouttime = now.TimeOfDay;
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

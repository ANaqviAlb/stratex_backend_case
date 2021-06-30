using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BackendCase.Model;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Data.Entity;

namespace BackendCase.NewFolder1
{
    public class scheduleSlots
    {
        BackendConnectionString db = new BackendConnectionString();
        public IEnumerable<Employees> slots()
        {
            var breaks = db.Breaks.ToList();
            var shift = db.Shifts.ToList();
            var leave = db.Leaves.ToList();


            var employees = db.Employees.ToList();


            List<Employees> datas = new List<Employees>();
            foreach (var data in employees)
            {
                Employees emp = new Employees();
                var employeeshift = shift.Where(x => x.EmployeeID == data.id).ToList();
                for (int index = 0; index < employeeshift.Count(); index++)
                {
                    var shiftdata = employeeshift[index];
                    var st = shiftdata.StartDateTime;
                    var et = shiftdata.EndDateTime;
                    if (breaks.Any(x => x.EmployeeID == data.id))
                    {
                        var berakst = shiftdata.StartDateTime;
                        var breaket = shiftdata.EndDateTime;
                        if (leave.Any(x => x.EmployeeID == data.id))
                        {
                            var count1 = 0;
                            var employeeleaves = leave.Where(x => x.EmployeeID == data.id).ToList();
                            for (int index1 = 0; index1 < employeeleaves.Count(); index1++)
                            {
                                var item = employeeleaves[index1];
                                if (Convert.ToDateTime(st) < Convert.ToDateTime(item.StartDateTime)
                                                                              && Convert.ToDateTime(item.StartDateTime) < Convert.ToDateTime(et)
                                                                              && Convert.ToDateTime(item.EndDateTime) >= Convert.ToDateTime(et))
                                {
                                    item.EndDateTime = et;
                                    et = item.StartDateTime;
                                }
                                else if (Convert.ToDateTime(item.StartDateTime) <= Convert.ToDateTime(st)
                                                      && Convert.ToDateTime(item.EndDateTime) < Convert.ToDateTime(et)
                                                      && Convert.ToDateTime(item.EndDateTime) > Convert.ToDateTime(st))
                                {
                                    // adjust start time

                                    item.StartDateTime = st;
                                    
                                    st = item.EndDateTime;
                                }

                                else if (Convert.ToDateTime(item.StartDateTime) >= Convert.ToDateTime(st)
                                                                          && Convert.ToDateTime(item.EndDateTime) < Convert.ToDateTime(et)
                                                                          && Convert.ToDateTime(item.EndDateTime) > Convert.ToDateTime(st))
                                {

                                    if (employeeshift.Any(x => x.EndDateTime == et && x.StartDateTime == item.EndDateTime))
                                    {
                                        et = item.EndDateTime;
                                        employeeshift[index].EndDateTime = item.StartDateTime;
                                    }
                                    else
                                    {
                                        employeeshift.Add(new Shift
                                        {

                                            id = shiftdata.id,
                                            EmployeeID = shiftdata.EmployeeID,

                                            StartDateTime = item.EndDateTime,
                                            EndDateTime = et,

                                            ActivityID = shiftdata.ActivityID,


                                        });
                                        if (count1 == 0)
                                        {
                                            employeeshift[index].EndDateTime = item.StartDateTime;
                                        }
                                        st = item.EndDateTime;
                                        count1++;
                                    }

                                }
                                else if (Convert.ToDateTime(item.StartDateTime) < Convert.ToDateTime(st)
                                                                              && Convert.ToDateTime(item.EndDateTime) > Convert.ToDateTime(et)
                                                                              )
                                {
                                    if (employeeshift.Any(x => x.EndDateTime == et && x.StartDateTime == item.EndDateTime)) { }
                                    else
                                    {
                                        employeeshift.Add(new Shift
                                        {

                                            id = shiftdata.id,
                                            EmployeeID = shiftdata.EmployeeID,

                                            StartDateTime = item.EndDateTime,
                                            EndDateTime = et,

                                            ActivityID = shiftdata.ActivityID,


                                        });
                                        if (count1 == 0)
                                        {
                                            employeeshift[index].EndDateTime = item.StartDateTime;
                                        }
                                        st = item.EndDateTime;
                                        count1++;
                                    }
                                }
                            }
                            emp.leaves = employeeleaves;
                        }
                         
                        var count = 0;
                        var employeebreaks = breaks.Where(x => x.EmployeeID == data.id).ToList();
                        for (int index1 = 0; index1 < employeebreaks.Count(); index1++)
                        {
                            var item = employeebreaks[index1];
                            if (Convert.ToDateTime(st) < Convert.ToDateTime(item.StartDateTime)
                                                                          && Convert.ToDateTime(item.StartDateTime) < Convert.ToDateTime(et)
                                                                          && Convert.ToDateTime(item.EndDateTime) >= Convert.ToDateTime(et))
                            {
                                item.StartDateTime = st;
                                et = item.StartDateTime;
                            }
                            else if (Convert.ToDateTime(item.StartDateTime) <= Convert.ToDateTime(st)
                                                  && Convert.ToDateTime(item.EndDateTime) < Convert.ToDateTime(et)
                                                  && Convert.ToDateTime(item.EndDateTime) > Convert.ToDateTime(st))
                            {
                                // adjust start time

                                item.StartDateTime = et;
                                st = item.EndDateTime;
                            }
                            
                            else if (Convert.ToDateTime(item.StartDateTime) >= Convert.ToDateTime(st)
                                                                      && Convert.ToDateTime(item.EndDateTime) < Convert.ToDateTime(et)
                                                                      && Convert.ToDateTime(item.EndDateTime) > Convert.ToDateTime(st))
                            {

                                if (employeeshift.Any(x => x.EndDateTime == et && x.StartDateTime == item.EndDateTime))
                                {
                                    et = item.EndDateTime;
                                    employeeshift[index].EndDateTime = item.StartDateTime;
                                }
                                else
                                {
                                    employeeshift.Add(new Shift
                                    {

                                        id = shiftdata.id,
                                        EmployeeID = shiftdata.EmployeeID,

                                        StartDateTime = item.EndDateTime,
                                        EndDateTime = et,

                                        ActivityID = shiftdata.ActivityID,


                                    });
                                    if (count == 0)
                                    {
                                        employeeshift[index].EndDateTime = item.StartDateTime;
                                    }
                                    st = item.EndDateTime;
                                    count++;
                                }

                            }
                            else if (Convert.ToDateTime(item.StartDateTime) < Convert.ToDateTime(st)
                                                                          && Convert.ToDateTime(item.EndDateTime) > Convert.ToDateTime(et)
                                                                          )
                            {
                                if (employeeshift.Any(x => x.EndDateTime == et && x.StartDateTime == item.EndDateTime)) { }
                                else
                                {
                                    employeeshift.Add(new Shift
                                    {

                                        id = shiftdata.id,
                                        EmployeeID = shiftdata.EmployeeID,

                                        StartDateTime = item.EndDateTime,
                                        EndDateTime = et,

                                        ActivityID = shiftdata.ActivityID,


                                    });
                                    if (count == 0)
                                    {
                                        employeeshift[index].EndDateTime = item.StartDateTime;
                                    }
                                    st = item.EndDateTime;
                                    count++;
                                }
                            }
                        }
                            emp.breaks = employeebreaks;
                        }
                        emp.shifts = employeeshift;
                    }
                   
                
                datas.Add(emp);
            }

            
            return datas;
        }
    }      

}
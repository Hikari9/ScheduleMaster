using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace ScheduleMaster
{
    namespace Classes
    {

        /// <summary>
        /// Stores week-based time information.
        /// </summary>

        public class Time : IComparable
        {

            /// <summary>
            /// holds integer value of total minutes in weekly basis
            /// rawMinutes = 0 signifies 12AM [Monday]
            /// </summary>

            protected internal int rawMinutes;

            /// <summary>
            /// The integer value of total minutes of Time object.
            /// [ Monday 12:00 AM = 0 ]
            /// </summary>

            public int raw() { if (this == null) return 0; return rawMinutes; }

            /// <summary>
            /// rawMinutes conversion variables
            /// </summary>

            protected internal static int MINUTE_MASK = 60;
            protected internal static int HOUR_MASK = 24 * MINUTE_MASK;
            protected internal static int DAY_MASK = 7 * HOUR_MASK;

            /// <summary>
            /// Minutes part of Time object.
            /// </summary>

            public int minutes() { return rawMinutes % MINUTE_MASK; }

            /// <summary>
            /// Hours part of Time object.
            /// [ follows military hours ]
            /// </summary>

            public int hours() { return (rawMinutes % HOUR_MASK) / MINUTE_MASK; }

            /// <summary>
            /// Days part of Time object.
            /// [ 0 = Monday ]
            /// </summary>

            public int days() { return (rawMinutes % DAY_MASK) / HOUR_MASK; }


            /// <summary>
            /// Minimum value of Time object. (Monday, 12:00 AM)
            /// </summary>

            public static Time MIN_VALUE = new Time(0);

            /// <summary>
            /// Maximum value of Time object. (Friday, 11:59 PM)
            /// </summary>

            public static Time MAX_VALUE = new Time(DAY_MASK - 1);

            /// string conversion

            /// <summary>
            /// Returns the string of the day of Time object.
            /// </summary>

            public string DayOfWeek() { return DayOfWeek(days()); }

            /// <summary>
            /// Static function that returns the string value of the integer day.
            /// </summary>
            /// <param name="day">integer value of day [ 0 = "Monday" ]</param>

            public static string DayOfWeek(int day) { return DayOfWeekArray[day % DayOfWeekArray.Length]; } /// dayOfWeek(static) for global use
            
            /// <summary>
            /// Array that stores the string value of the day of the week.
            /// </summary>

            protected internal static string[] DayOfWeekArray = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };


            /// <summary>
            /// The string value of time in military format.
            /// </summary>

            public string ToMilitaryTimeString() { return hours().ToString("D2") + ":" + minutes().ToString("D2"); }

            /// <summary>
            /// The string value of time in military format (no colon).
            /// </summary>

            public string ToRawMilitaryTimeString() { return hours().ToString("D2") + minutes().ToString("D2"); }

            /// <summary>
            /// The string value of time in (AM/PM) format
            /// </summary>

            public string ToTimeString()
            {
                int h = hours();

                string suffix;
                if (h < 12) suffix = "AM";
                else suffix = "PM";

                h %= 12;
                if (h == 0) h = 12;

                return h.ToString("D2") + ":" + minutes().ToString("D2") + " " + suffix;
            }

            /// <summary>
            /// The string values of day of the week and the military time.
            /// </summary>

            public override string ToString() { return DayOfWeek() + " " + ToMilitaryTimeString(); }

            /// <summary>
            /// Mapper from string to integer value of the day of the week. [ "Monday" = 0 ]
            /// </summary>

            public static Dictionary<string, int> getDayOfWeek = new Dictionary<string, int>()
        {
            { "", 0 },
            //{ null, 0 },
            { "Monday",     0 },
            { "Tuesday",    1 },
            { "Wednesday",  2 },
            { "Thursday",   3 },
            { "Friday",     4 },
            { "Saturday",   5 },
            { "Sunday",     6 },
        };

            /// constructors

            /// <summary>
            /// Constructs a default time object. (Monday, 12:00 AM)
            /// </summary>

            public Time() { rawMinutes = 0; }

            /// <summary>
            /// Constructs a time object object based on raw time in minutes.
            /// </summary>
            /// <param name="raw">The total minutes in integer. [ 0 = Monday, 12:00 AM ]</param>

            public Time(int raw) { while (raw < 0) raw += DAY_MASK; rawMinutes = raw % DAY_MASK; }

            /// <summary>
            /// Constructs a copy of time object.
            /// </summary>
            /// <param name="t">The time object to copy.</param>

            public Time(Time t) { rawMinutes = t.rawMinutes; }

            /// <summary>
            /// Constructs a time object based on days, hours, and minutes.
            /// </summary>
            /// <param name="day">The day in integer format. [ 0 = Monday ]</param>
            /// <param name="hr">The hour in integer format.</param>
            /// <param name="min">The minute in integer format.</param>

            public Time(int day, int hr, int min) { rawMinutes = ((day * HOUR_MASK) + (hr * MINUTE_MASK) + min) % DAY_MASK; }

            /// <summary>
            /// Constructs a time object based on days, hours, and minutes.
            /// </summary>
            /// <param name="day">The day in string format. [ "Monday" = 0 ]</param>
            /// <param name="hr">The hour in integer format.</param>
            /// <param name="min">The minute in integer format.</param>

            public Time(string day, int hr, int min) { rawMinutes = ((getDayOfWeek[day] * HOUR_MASK) + (hr * MINUTE_MASK) + min) % DAY_MASK; }

            /// <summary>
            /// Constructs a time object based on days, hours, and minutes.
            /// </summary>
            /// <param name="day">The day in integer format. [ 0 = Monday ]</param>
            /// <param name="time">The hours and minutes in string format [ military time "HH:MM" ]</param>

            public Time(int day, string time)
            {
                string[] s = time.Split(':');
                int hr = int.Parse(s[0]);
                int min = int.Parse(s[1]);
                rawMinutes = ((day * HOUR_MASK) + (hr * MINUTE_MASK) + min) % DAY_MASK;
            }

            /// <summary>
            /// Constructs a time object based on days, hours, and minutes.
            /// </summary>
            /// <param name="day">The day in string format. [ "Monday" = 0 ]</param>
            /// <param name="time">The hours and minutes in string format [ military time "HH:MM" ]</param>

            public Time(string day, string time)
            {
                string[] s = time.Split(':');
                int hr = int.Parse(s[0]);
                int min = int.Parse(s[1]);
                rawMinutes = ((getDayOfWeek[day] * HOUR_MASK) + (hr * MINUTE_MASK) + min) % DAY_MASK;
            }

            /// <summary>
            /// Constructs a time object based on days, hours, and minutes.
            /// </summary>
            /// <param name="day">The day in int format. [ 0 = Monday ]</param>
            /// <param name="time">The hours and minutes in (integer) military time format [ HHMM ]</param>

            public Time(int day, int time)
            {
                int hr = time / 100;
                int min = time % 100;
                rawMinutes = (day * HOUR_MASK + (hr * MINUTE_MASK) + min) % DAY_MASK;
            }

            /// <summary>
            /// Constructs a time object based on days, hours, and minutes.
            /// </summary>
            /// <param name="day">The day in string format. [ "Monday" = 0 ]</param>
            /// <param name="time">The hours and minutes in (integer) military time format [ HHMM ]</param>

            public Time(string day, int time)
            {
                int hr = time / 100;
                int min = time % 100;
                rawMinutes = ((getDayOfWeek[day] * HOUR_MASK) + (hr * MINUTE_MASK) + min) % DAY_MASK; 
            }

            /// overload operators
            /// increment, decrement, add, subtract

            public static Time operator ++(Time t) { t.rawMinutes = (t.raw() + 1) % DAY_MASK; return t; }
            public static Time operator --(Time t) { t.rawMinutes = (t.raw() - 1) % DAY_MASK; return t; }
            public static Time operator +(Time t, Time t2) { return new Time(t.rawMinutes + t2.rawMinutes); }
            public static Time operator +(Time t, int t2) { return new Time(t.rawMinutes + t2); }
            public static Time operator -(Time t, Time t2) { return new Time(t.rawMinutes - t2.rawMinutes); }
            public static Time operator -(Time t, int t2) { return new Time(t.rawMinutes - t2); }

            /// <summary>
            /// Compares two Time objects.
            /// </summary>
            /// <param name="obj">The Time object to compare</param>

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                Time t = obj as Time;
                if (t == null) throw new ArgumentException("Object is not an instance of Time");
                return raw() - t.raw();
            }

            /// <summary>
            /// Compares the content of two Time objects.
            /// </summary>
            /// <param name="obj">The Time object to compare</param>

            public override bool Equals(object obj)
            {
                return CompareTo(obj) == 0;
            }

            /// <summary>
            /// Gets Hash Code of Time.
            /// </summary>

            public override int GetHashCode()
            {
                return raw().GetHashCode();
            }

        }

        /// <summary>
        /// Handles information of a subject.
        /// </summary>

        class Subject : IComparable
        {

            /// <summary>
            /// The title of the Subject.
            /// </summary>

            protected internal string title { get; set; }

            /// <summary>
            /// The title of the Subject.
            /// </summary>

            public string Title
            {
                get { return title; }
            }

            /// <summary>
            /// The pointer to the Professor that handles the Subject.
            /// </summary>

            protected internal Professor professor { get; set; }

            /// <summary>
            /// The pointer to the Professor that handles the Subject.
            /// </summary>

            public Professor GetProfessor
            {
                get { return professor; }
            }

            /// <summary>
            /// The pointer to the Room that handles the Subject.
            /// </summary>

            protected internal Room room { get; set; }

            /// <summary>
            /// The pointer to the Room that handles the Subject.
            /// </summary>

            public Room GetRoom
            {
                get { return room; }
            }

            /// <summary>
            /// The pointer to the Schedule associated with the Subject.
            /// </summary>

            protected internal Schedule schedule { get; set; }

            /// <summary>
            /// The pointer to the Schedule associated with the Subject.
            /// </summary>

            public Schedule GetSchedule
            {
                get { return schedule; }
            }

            /// <summary>
            /// Constructs a new Subject.
            /// </summary>
            /// <param name="title">Title of the Subject</param>
            /// <param name="professor">Pointer to the Professor</param>
            /// <param name="room">Pointer to the Room</param>

            public Subject(string title, Professor professor, Room room)
            {
                this.title = title.NormalizeWhiteSpaces();
                this.professor = professor;
                this.room = room;
                schedule = null;
            }

            /// <summary>
            /// Constructs an empty Subject.
            /// </summary>

            public Subject()
            {
                title = "No title";
                professor = new Professor();
                room = new Room();
                schedule = null;
            }

            /// <summary>
            /// Converts Subject to string.
            /// </summary>

            public override string ToString()
            {
                return Title + "\n" + GetProfessor.ToString() + "\n" + GetRoom.ToString() + "\n";
            }

            /// <summary>
            /// Compares content of two Subjects.
            /// </summary>
            /// <param name="obj">Object to compare.</param>

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                Subject s = obj as Subject;
                if (s == null)
                {
                    // try string
                    string str = obj as string;
                    if (str == null) throw new ArgumentException("Object is not an instance of Subject.");
                    return ToString().CompareTo(str);
                }
                return ToString().CompareTo(s.ToString());
            }

            /// <summary>
            /// Compares content of two Subjects.
            /// </summary>
            /// <param name="obj">Object to compare.</param>

            public override bool Equals(object obj)
            {
                return CompareTo(obj) == 0;
            }

            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }

        }

        /// <summmary>
        /// Stores information of a schedule.
        /// </summmary>

        class Schedule : IComparable
        {

            /// <summary>
            /// Pointer to the Subject that is associated with the schedule.
            /// </summary>

            protected internal Subject subject { get; set; }

            /// <summary>
            /// Pointer to the Subject that is associated with the schedule.
            /// </summary>

            public Subject GetSubject
            {
                get { return subject; }
            }

            /// <summary>
            /// Pointer to the Professor that handles the schedule.
            /// </summary>

            protected internal Professor professor
            {
                get { return subject.professor; }
                set { subject.professor = value; }
            }

            /// <summary>
            /// Pointer to the Professor that handles the schedule.
            /// </summary>

            public Professor GetProfessor
            {
                get { return professor; }
            }

            /// <summary>
            /// Pointer to the Room that handles the schedule.
            /// </summary>

            protected internal Room room
            {
                get { return subject.room; }
                set { subject.room = value; }
            }

            /// <summary>
            /// Pointer to the Room that handles the schedule.
            /// </summary>

            public Room GetRoom
            {
                get { return room; }
            }

            /// <summary>
            /// The start time of the schedule.
            /// </summary>

            protected internal Time start { get; set; }

            /// <summary>
            /// The start time of the schedule.
            /// </summary>

            public Time StartTime
            {
                get { return start; }
            }

            /// <summary>
            /// The end time of the schedule.
            /// </summary>

            protected internal Time end { get; set; }

            /// <summary>
            /// The end time of the schedule.
            /// </summary>

            public Time EndTime
            {
                get { return end; }
            }

            /// constructors

            /// <summary>
            /// Constructs a new Schedule.
            /// </summary>

            public Schedule()
            {
                subject = new Subject();
                subject.schedule = this;
                start = Time.MIN_VALUE;
                end = Time.MAX_VALUE;
            }

            /// <summary>
            /// Constructs a copy of another schedule.
            /// </summary>
            /// <param name="s">The schedule to copy.</param>

            public Schedule(Schedule s)
            {
                subject = s.GetSubject;
                subject.schedule = this;
                start = s.StartTime;
                end = s.EndTime;
            }

            /// <summary>
            /// Constructs a new, defined schedule.
            /// </summary>
            /// <param name="p">The pointer to the professor.</param>
            /// <param name="r">The pointer to the room.</param>
            /// <param name="start">The initial time of the schedule.</param>
            /// <param name="end">The ending time of the schedule.</param>

            public Schedule(Subject s, Time start, Time end)
            {
                subject = s;
                subject.schedule = this;
                this.start = start;
                this.end = end;
            }

            /// string conversion

            /// <summary>
            /// Returns schedule information in form of a string.
            /// (For debugging purposes)
            /// </summary>

            public override string ToString()
            {
                return GetSubject.ToString() + StartTime.ToString() + " to " + EndTime.ToString() + "\n";
            }

            /// <summary>
            /// Sorter class for Schedules.
            /// Sorts by increasing StartTime.
            /// </summary>

            public class CompareByStartTime : IComparer
            {
                int IComparer.Compare(object x, object y)
                {
                    if (y == null) return 1;
                    Schedule a = x as Schedule;
                    Schedule b = y as Schedule;
                    if (a == null || b == null)
                        throw new ArgumentException("Object is not an instance of Schedule.");
                    return a.StartTime.CompareTo(b.StartTime);
                }
            }

            /// <summary>
            /// Compares the content of two Schedules.
            /// (negative if less, zero if equal, positive if greater)
            /// </summary>
            /// <param name="obj">The Schedule to compare.</param>

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                Schedule s = obj as Schedule;
                if (s == null) throw new ArgumentException("Object is not an instance of Schedule.");
                int cmp = StartTime.CompareTo(s.StartTime);
                if (cmp == 0)
                {
                    cmp = EndTime.CompareTo(s.EndTime);
                    if (cmp == 0)
                        cmp = GetSubject.CompareTo(s.GetSubject);
                }
                return cmp;
            }

            /// <summary>
            /// Compares the content of two Schedules.
            /// </summary>
            /// <param name="obj">The Schedule object to compare.</param>

            public override bool Equals(object obj)
            {
                return CompareTo(obj) == 0;
            }

            /// <summary>
            /// Get Hash Code for this Schedule.
            /// </summary>

            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }

            /// <summary>
            /// Header Information of Schedule array.
            /// </summary>

            public static string[] GetHeaderArray()
            {
                string[] headers = new string[]{
                    "Subject",
                    "Last Name",
                    "First Name",
                    "Department",
                    "ID No",
                    "Contact Info",
                    "Building",
                    "Room",
                    "Start Day",
                    "Start Time",
                    "End Day",
                    "End Time"
                };
                return headers;
            }

            /// <summary>
            /// Converts Schedule to string array.
            /// </summary>

            public string[] ToArray()
            {
                string[] data = new string[]{
                    GetSubject.Title,
                    GetProfessor.LastName,
                    GetProfessor.FirstName,
                    GetProfessor.Department,
                    GetProfessor.ID,
                    GetProfessor.Contact,
                    GetRoom.Building,
                    GetRoom.RoomNumber,
                    StartTime.DayOfWeek(),
                    StartTime.ToRawMilitaryTimeString(),
                    EndTime.DayOfWeek(),
                    EndTime.ToRawMilitaryTimeString()
                };
                return data;
            }

            /// <summary>
            /// Header Information of small Schedule array.
            /// </summary>
            /// <returns></returns>

            public static string[] GetSmallHeaderArray()
            {
                string[] headers = new string[]{
                    "Subject",
                    "ID",
                    "Professor",
                    "Start",
                    "End",
                    "Day",
                    "Classroom"
                };
                return headers;
            }

            /// <summary>
            /// Converts Schedule's essential information to string array.
            /// </summary>

            public string[] ToSmallArray()
            {
                string[] data = new string[]{
                    GetSubject.Title,
                    GetProfessor.ID,
                    GetProfessor.Name(),
                    StartTime.ToRawMilitaryTimeString(),
                    EndTime.ToRawMilitaryTimeString(),
                    StartTime.DayOfWeek(),
                    GetRoom.ToString()                   
                };
                return data;
            }

        }

        /// <summary>
        /// ScheduleWrapper stores an array of time frames such that each time frame corresponds to a certain Schedule object.
        /// </summary>

        class ScheduleWrapper
        {

            /// <summary>
            /// Contains the sorted list of all the schedules.
            /// </summary>

            protected internal ArrayList list { get; set; }

            /// <summary>
            /// Contains the sorted list of all the schedules.
            /// </summary>
            /// <returns></returns>

            public ArrayList GetArrayList
            {
                get { return list; }
            }

            /// <summary>
            /// Constructs an empty ScheduleWrapper.
            /// </summary>

            public ScheduleWrapper() { list = new ArrayList(); }

            /// <summary>
            /// Constructs a cloned copy of another ScheduleWrapper.
            /// </summary>
            /// <param name="sw">The SchedulWrapper to copy.</param>

            public ScheduleWrapper(ScheduleWrapper sw) { list = (ArrayList)sw.list.Clone(); }

            /// conflict-checking

            /// <summary>
            /// Retrieves the integer index of (one) conflicting Schedule.
            /// Returns a negative index if no conflict is found.
            /// Note that the insertion point is the (~) of the negative return value.
            /// </summary>
            /// <param name="s">The Schedule to test for conflicts.</param>

            protected internal int GetConflictIndex(Schedule s)
            {

                // get bound of search based on Schedule Time

                int lowerBound = list.BinarySearch(s, new Schedule.CompareByStartTime());
                if (lowerBound >= 0) return lowerBound; // conflict with same StartTime found -> return index

                // get lower bound index
                lowerBound = ~lowerBound;

                // check if previous schedule's EndTime
                // conflicts with current schedule's StartTime

                if (lowerBound > 0)
                {
                    Schedule previous = (Schedule)list[lowerBound - 1];
                    if (previous.EndTime.CompareTo(s.StartTime) > 0) return lowerBound - 1;
                }

                // check if next schedule's StartTime
                // conflicts with current schedule's EndTime

                if (lowerBound < list.Count)
                {
                    Schedule next = (Schedule)list[lowerBound];
                    if (next.StartTime.CompareTo(s.EndTime) < 0) return lowerBound;
                }

                // no conflict, return (~) of insertion point
                return ~lowerBound;

            }

            /// <summary>
            /// Returns the Schedule object of a conflicting schedule.
            /// returns null if no conflict is found.
            /// </summary>
            /// <param name="s">The Schedule to test for conflicts.</param>

            public Schedule GetConflict(Schedule s)
            {
                int conflict = GetConflictIndex(s);
                if (conflict >= 0) return (Schedule)list[conflict];
                return null;
            }

            /// <summary>
            /// Checks if there is a conflict with a Schedule.
            /// Returns true if conflict is found, otherwise false.
            /// </summary>
            /// <param name="s">The Schedule to test for conflicts.</param>

            public bool HasConflict(Schedule s)
            {
                return GetConflictIndex(s) >= 0;
            }

            /// <summary>
            /// Inserts a new Schedule.
            /// Returns null if schedule is inserted with no conflict, otherwise the conflicting schedule and does not insert.
            /// </summary>
            /// <param name="s">The Schedule to insert.</param>

            public Schedule InsertSchedule(Schedule s)
            {
                int conflict = GetConflictIndex(s);
                if (conflict >= 0) return (Schedule)list[conflict];
                list.Insert(~conflict, s);
                return null;
            }

            /// <summary>
            /// Gets index of Schedule.
            /// Returns a negative number if Schedule does not exist.
            /// </summary>
            /// <param name="s">The Schedule to find</param>

            protected internal int GetIndex(Schedule s)
            {
                int ind = GetConflictIndex(s);
                if (ind < 0) return -1;
                Schedule s2 = (Schedule)list[ind];
                if (!s.Equals(s2)) return -1;
                return ind;
            }

            public Schedule GetSchedule(Schedule s)
            {
                int ind = GetIndex(s);
                if (ind < 0) return null;
                return (Schedule)list[ind];
            }

            /// <summary>
            /// Checks if Schedule is in the ScheduleWrapper.
            /// </summary>
            /// <param name="s">The Schedule to find</param>
            /// <returns></returns>

            public bool Contains(Schedule s)
            {
                return GetIndex(s) >= 0;
            }

            /// <summary>
            /// Deletes a Schedule from the ScheduleWrapper.
            /// Returns true if Schedule is successfully deleted.
            /// </summary>
            /// <param name="s">The Schedule to delete</param>

            public bool DeleteSchedule(Schedule s)
            {
                int ind = GetIndex(s);
                if (ind < 0) return false;
                list.RemoveAt(ind);
                return true;
            }

        }

        /// <summary>
        /// Stores information for a Professor.
        /// </summary>

        class Professor : IComparable
        {

            /// Personal Information (you may add more)

            /// <summary>
            /// The first name of the Professor.
            /// </summary>

            public string FirstName { get; set; }

            /// <summary>
            /// The last name of the Professor.
            /// </summary>

            public string LastName { get; set; }

            /// <summary>
            /// The department of the Professor.
            /// </summary>

            public string Department { get; set; }

            /// <summary>
            /// The name of the Professor. "LastName, FirstName"
            /// </summary>

            public string Name() { return LastName + ", " + FirstName; }

            /// <summary>
            /// The pointer to the Schedules of the Professor.
            /// </summary>

            protected internal ScheduleWrapper schedules { get; set; }

            /// <summary>
            /// The pointer to the Schedules of the Professor.
            /// </summary>

            public ScheduleWrapper GetSchedules
            {
                get { return schedules; }
            }

            /// <summary>
            /// ID Number of the Professor.
            /// </summary>

            public string ID { get; set; }

            /// <summary>
            /// Contact Info of the Professor.
            /// </summary>

            public string Contact { get; set; }


            /// <summary>
            /// Constructs an empty Professor object.
            /// </summary>

            public Professor()
            {
                LastName = FirstName = Department = "";
                ID = Contact = "";
                schedules = new ScheduleWrapper();
            }

            /// <summary>
            /// Constructs a new Professor object.
            /// </summary>
            /// <param name="LastName">Surname of the Professor.</param>
            /// <param name="FirstName">First name of the Professor.</param>
            /// <param name="Department">The department of the Professor.</param>
            /// <param name="ID">ID Number of the Professor.</param>

            public Professor(string LastName, string FirstName, string Department, string ID, string Contact)
            {
                this.LastName = LastName.NormalizeWhiteSpaces();
                this.FirstName = FirstName.NormalizeWhiteSpaces();
                this.Department = Department.NormalizeWhiteSpaces();
                this.ID = ID;
                this.Contact = Contact;
                schedules = new ScheduleWrapper();
            }

            /// <summary>
            /// Constructs a new Professor object.
            /// </summary>
            /// <param name="RawName">The name of the Professor in the format: "LastName, FirstName"</param>
            /// <param name="Department">The department of the Professor.</param>
            /// <param name="ID">ID Number of the Professor.</param>
            /// <param name="Contact">Contact Number of the Professor.</param>

            public Professor(string RawName, string Department, string ID, string Contact)
            {
                RawName = RawName.NormalizeWhiteSpaces();
                int comma = RawName.IndexOf(',');
                if (comma == -1)
                {
                    LastName = RawName;
                    FirstName = "";
                }
                else
                {
                    LastName = RawName.Substring(0, comma).Trim();
                    FirstName = RawName.Substring(comma + 1).Trim();
                }
                this.Department = Department.NormalizeWhiteSpaces();
                this.ID = ID;
                this.Contact = Contact;
                schedules = new ScheduleWrapper();
            }

            /// string conversion

            /// <summary>
            /// Returns the name and the department of the Professor.
            /// </summary>

            public override string ToString() {
                if (Department == "") return Name();
                return Name() + " (" + Department + ")";
            }

            /// <summary>
            /// Returns complete information of the professor.
            /// </summary>

            public string ToCompleteString() { return ToString() + ", " + ID + ", " + Contact; }

            /// <summary>
            /// Returns array of information of the Professor.
            /// </summary>

            public string[] Information()
            {
                return new string[]{
                    LastName, FirstName, Department, ID, Contact
                };
            }

            /// <summary>
            /// Comparer class that sorts Professors by Name.
            /// </summary>

            public class CompareByName : IComparer
            {
                int IComparer.Compare(object x, object y)
                {
                    if (y == null) return 1;
                    Professor a = x as Professor;
                    Professor b = y as Professor;
                    if (a == null)
                    {
                        // try as string
                        string sa = x as string;
                        if (sa == null) throw new ArgumentException("Object is not an instance of Professor/String.");
                        if (b == null)
                        {
                            // try as string
                            string sb = y as string;
                            if (sb == null) throw new ArgumentException("Object is not an instance of Professor/String.");
                            return sa.ToLower().CompareTo(sb.ToLower());
                        }
                        return sa.ToLower().CompareTo(b.Name().ToLower());
                    }
                    if (b == null)
                    {
                        // try as string
                        string sb = y as string;
                        if (sb == null) throw new ArgumentException("Object is not an instance of Professor/String.");
                        return a.Name().ToLower().CompareTo(sb.ToLower());
                    }
                    // both Professors
                    return a.Name().ToLower().CompareTo(b.Name().ToLower());
                }
            }

            /// <summary>
            /// Compares names of two Professors.
            /// (negative if less, zero if equal, positive if greater)
            /// </summary>
            /// <param name="obj">The Professor object to compare.</param>

            public int CompareTo(object obj)
            {
                try
                {
                    if (obj == null) return 1;
                    Professor y = obj as Professor;
                    if (y == null)
                    {
                        // try as string
                        string s = obj as string;
                        if (s == null) throw new ArgumentException("Object is not an instance of Professor");
                        return ToCompleteString().CompareTo(s);
                    }
                    return ToCompleteString().CompareTo(y.ToCompleteString());
                }
                catch
                {
                    return 1;
                }
            }

            /// <summary>
            /// Compares the content of two Professors.
            /// </summary>
            /// <param name="obj">The Professor object to compare.</param>

            public override bool Equals(object obj)
            {
                return CompareTo(obj) == 0;
            }

            /// <summary>
            /// Get Hash Code for this Professor.
            /// </summary>

            public override int GetHashCode()
            {
                return ToCompleteString().GetHashCode();
            }

        }

        /// <summary>
        /// Stores information for a classroom.
        /// </summary>

        class Room : IComparable
        {

            /// <summary>
            /// The name of the building where the Room is located.
            /// </summary>

            public string Building { get; set; }

            /// <summary>
            /// The number of the Room.
            /// </summary>

            public string RoomNumber { get; set; }

            /// <summary>
            /// The pointer to the Schedules of the Room.
            /// </summary>

            protected internal ScheduleWrapper schedules { get; set; }

            /// <summary>
            /// The pointer to the Schedules of the Room.
            /// </summary>

            public ScheduleWrapper GetSchedules
            {
                get { return schedules; }
            }

            /// constructors

            /// <summary>
            /// Constructs an empty Room object.
            /// </summary>

            public Room() { schedules = new ScheduleWrapper(); }

            /// <summary>
            /// Constructs a new Room object.
            /// </summary>
            /// <param name="name">The name of the Room. [ "Building RoomNumber" ]</param>

            public Room(string name)
            {
                name = name.NormalizeWhiteSpaces();
                int space = name.LastIndexOf(' ');
                if (space < 0)
                {
                    RoomNumber = "";
                    Building = name;
                }
                else
                {
                    RoomNumber = name.Substring(space + 1);
                    Building = name.Substring(0, space);
                }
                schedules = new ScheduleWrapper();
            }

            /// <summary>
            /// Constructs a new Room object.
            /// </summary>
            /// <param name="building">The building where the Room is located.</param>
            /// <param name="roomnumber">The number of the Room.</param>

            public Room(string building, string roomnumber)
            {
                Building = building.NormalizeWhiteSpaces();
                RoomNumber = roomnumber.NormalizeWhiteSpaces();
                schedules = new ScheduleWrapper();
            }

            /// string conversion

            /// <summary>
            /// Converts Room object to string. "Building RoomNumber"
            /// </summary>

            public override string ToString() { return (Building + " " + RoomNumber).Trim(); }

            /// <summary>
            /// Compares two rooms by building.
            /// </summary>

            public class CompareByBuilding : IComparer
            {
                int IComparer.Compare(object x, object y)
                {
                    if (y == null) return 1;
                    Room a = x as Room;
                    Room b = y as Room;
                    if (a == null)
                    {
                        // try as string
                        string sa = x as string;
                        if (sa == null) throw new ArgumentException("Object is not an instance of Room/String");
                        if (b == null)
                        {
                            // try as string
                            string sb = y as string;
                            if (sb == null) throw new ArgumentException("Object is not an instance of Room/String");
                            return sa.CompareTo(sb);
                        }
                        return sa.CompareTo(b.Building);
                    }
                    if (b == null)
                    {
                        // try as string
                        string sb = y as string;
                        if (sb == null) throw new ArgumentException("Object is not an instance of Room/String");
                        return a.Building.CompareTo(sb);
                    }
                    // both are Rooms
                    return a.Building.CompareTo(b.Building);
                }
            }

            /// <summary>
            /// Compares two Rooms.
            /// (negative if less, zero if equal, positive if greater)
            /// </summary>
            /// <param name="obj">Room object to compare.</param>

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                string s = obj as string;
                if (s == null)
                {
                    Room x = obj as Room;
                    if (x == null) throw new ArgumentException("Object is not an instance of Professor");
                    return ToString().CompareTo(x.ToString());
                }
                return ToString().CompareTo(s);
            }

            /// <summary>
            /// Compares the content of two Rooms.
            /// </summary>
            /// <param name="obj">The Room object to compare</param>

            public override bool Equals(object obj)
            {
                try
                {
                    if (obj == null) return false;
                    Room r = obj as Room;
                    return ToString().Equals(r.ToString());
                }
                catch
                {
                    return false;
                }
            }

            /// <summary>
            /// Get Hash Code for this Room.
            /// </summary>

            public override int GetHashCode()
            {
                return ToString().GetHashCode();
            }

        }

        /// <summary>
        /// Stores a database of schedules of professors and rooms.
        /// </summary>

        class ScheduleDatabase
        {

            /// <summary>
            /// The list of Professors of the database.
            /// </summary>

            protected internal ArrayList AllProfessors;

            /// <summary>
            /// The list of Rooms of the database.
            /// </summary>

            protected internal ArrayList AllRooms;

            /// <summary>
            /// Constructs a new ScheduleDatabase.
            /// </summary>

            public ScheduleDatabase()
            {
                AllProfessors = new ArrayList();
                AllRooms = new ArrayList();
            }

            /// <summary>
            /// Retrieves the data in a list mapped by a key.
            /// Returns null if no such data exists.
            /// </summary>
            /// <param name="list">The sorted list to check.</param>
            /// <param name="key">The data to map with.</param>

            protected internal static object GetData(ArrayList list, object key)
            {
                int ind;
                string s = key as string;
                if (s != null)
                {
                    s = s.NormalizeWhiteSpaces();
                    ind = list.BinarySearch(s);
                }
                else
                {
                    ind = list.BinarySearch(key);
                }
                if (ind < 0) return null;
                return list[ind];
            }

            /// <summary>
            /// Retrieves the data in a list mapped by a key.
            /// Returns null if no such data exists.
            /// </summary>
            /// <param name="list">The sorted list to check.</param>
            /// <param name="key">The data to map with.</param>
            /// <param name="comparator">IComparer object for sorting.</param>

            protected internal static object GetData(ArrayList list, object key, IComparer comparator)
            {
                int ind;
                string s = key as string;
                if (s != null)
                {
                    s = s.NormalizeWhiteSpaces();
                    ind = list.BinarySearch(s, comparator);
                }
                else
                {
                    ind = list.BinarySearch(key, comparator);
                }
                if (ind < 0) return null;
                return list[ind];
            }

            /// <summary>
            /// Retrieves the Professor object mapped by name.
            /// Returns null if no such Professor exists.
            /// </summary>
            /// <param name="professor">The Professor to get from database</param>

            public Professor GetProfessor(Professor professor)
            {
                return (Professor)GetData(AllProfessors, professor, new Professor.CompareByName());
            }

            /// <summary>
            /// Retrieves the Professor object mapped by name.
            /// Returns null if no such Professor exists in database.
            /// </summary>
            /// <param name="Name">The name of the professor "LastName, FirstName"</param>

            public Professor GetProfessor(string Name)
            {
                return (Professor)GetData(AllProfessors, Name, new Professor.CompareByName());
            }

            /// <summary>
            /// Retrieves the Professor object mapped by name.
            /// Returns null if no such Professor exits in database.
            /// </summary>
            /// <param name="Last">Surname of the Professor</param>
            /// <param name="First">First name of the Professor</param>
            /// <returns></returns>

            public Professor GetProfessor(string Last, string First)
            {
                return GetProfessor((Last + ", " + First).NormalizeWhiteSpaces());
            }

            /// <summary>
            /// Retrieves the Room object mapped by name.
            /// Returns null if no such Room exists in database.
            /// </summary>
            /// <param name="room">The Room to get from database</param>

            public Room GetRoom(Room room)
            {
                return (Room)GetData(AllRooms, room);
            }

            /// <summary>
            /// Retrieves the Room object mapped by name.
            /// Returns null if no such Room exists in database.
            /// </summary>
            /// <param name="Name">The name of the room "Building RoomNumber"</param>

            public Room GetRoom(string Name)
            {
                return (Room)GetData(AllRooms, Name);
            }

            /// <summary>
            /// Retrieves the Room object mapped by name.
            /// Returns null if no such Room exists in database.
            /// </summary>
            /// <param name="Building">The building where the Room is located</param>
            /// <param name="RoomNumber">The room number</param>

            public Room GetRoom(string Building, string RoomNumber)
            {
                return (Room)GetData(AllRooms, Building + " " + RoomNumber);
            }

            /// <summary>
            /// Adds a Professor to the database.
            /// If Professor already exists, the method returns existing Professor.
            /// </summary>
            /// <param name="professor">The professor to add</param>

            public Professor AddProfessor(Professor professor)
            {
                int ind = AllProfessors.BinarySearch(professor, new Professor.CompareByName());
                if (ind < 0)
                {
                    ind = ~ind;
                    AllProfessors.Insert(ind, professor);
                }
                return professor = (Professor)AllProfessors[ind];
            }

            /// <summary>
            /// Adds a Room to the database.
            /// If Room already exists, the method returns the existing Room.
            /// </summary>
            /// <param name="room">The Room to add.</param>

            public Room AddRoom(Room room)
            {
                int ind = AllRooms.BinarySearch(room);
                if (ind < 0)
                {
                    ind = ~ind;
                    AllRooms.Insert(ind, room);
                }
                return room = (Room)AllRooms[ind];
            }

            /// conflict checking

            /// <summary>
            /// Returns a conflicting Schedule in the database.
            /// Returns null if no conflict is found.
            /// </summary>
            /// <param name="s">The Schedule to test for conflicts.</param>

            public Schedule GetConflict(Schedule s)
            {
                Schedule conflict = s.GetProfessor.GetSchedules.GetConflict(s);
                if (conflict == null) conflict = s.GetRoom.GetSchedules.GetConflict(s);
                return conflict;
            }

            /// <summary>
            /// Checks if a Schedule conflicts with one in the database.
            /// </summary>
            /// <param name="s">The Schedule to test for conflicts.</param>

            public bool HasConflict(Schedule s)
            {
                return GetConflict(s) != null;
            }

            /// <summary>
            /// Inserts a new Schedule to the database.
            /// (Returns false and does not insert the schedule if a conflict is found)
            /// </summary>
            /// <param name="s">The Schedule to test for conflicts.</param>

            public bool InsertSchedule(Schedule s)
            {
                if (HasConflict(s)) return false;
                s.GetProfessor.GetSchedules.InsertSchedule(s);
                s.GetRoom.GetSchedules.InsertSchedule(s);
                return true;
            }

            /// <summary>
            /// Inserts a new Schedule to the database.
            /// (Returns false and does not insert the schedule if a conflict is found)
            /// </summary>
            /// <param name="p">The Professor of the Schedule.</param>
            /// <param name="r">The Room of the Schedule.</param>
            /// <param name="start">The initial time of the Schedule.</param>
            /// <param name="end">The ending time of the schedule.</param>

            public bool InsertSchedule(Subject subject, Time start, Time end)
            {
                Schedule s = new Schedule(subject, start, end);
                return InsertSchedule(s);
            }

            /// <summary>
            /// Deletes a Schedule.
            /// Returns true if Schedule is successfully deleted.
            /// </summary>
            /// <param name="s">Schedule to delete.</param>

            public bool DeleteSchedule(Schedule s)
            {
                if (s.GetProfessor.GetSchedules.Contains(s) && s.GetRoom.GetSchedules.Contains(s))
                {
                    s.GetProfessor.GetSchedules.DeleteSchedule(s);
                    s.GetRoom.GetSchedules.DeleteSchedule(s);
                    return true;
                }
                return false;
            }

            /// <summary>
            /// Deletes a Professor and all Schedules associated with the Professor.
            /// Returns true if Professor is found and successfully deleted.
            /// </summary>
            /// <param name="Name">Name of the Professor. [ "LastName, FirstName" ]</param>
            /// <returns></returns>

            public bool DeleteProfessor(string Name)
            {
                Name = Name.NormalizeWhiteSpaces();
                int ind = AllProfessors.BinarySearch(Name,new Professor.CompareByName());
                if (ind < 0) return false; // professor not found
                Professor x = (Professor)AllProfessors[ind];
                ArrayList schedules = x.GetSchedules.GetArrayList;
                for (int i = 0; i < schedules.Count; ++i)
                {
                    Schedule s = (Schedule)schedules[i];
                    // delete the respective room's schedule
                    s.GetRoom.GetSchedules.DeleteSchedule(s);
                }
                schedules.Clear();
                x.schedules = null;
                AllProfessors.RemoveAt(ind);
                return true;
            }

            /// <summary>
            /// Deletes a Professor and all Schedules associated with the Professor.
            /// Returns true if Professor is found and successfully deleted.
            /// </summary>
            /// <param name="LastName">Surname of the Professor.</param>
            /// <param name="FirstName">First name of the Professor.</param>

            public bool DeleteProfessor(string LastName, string FirstName)
            {
                return DeleteProfessor(LastName + ", " + FirstName);
            }

            /// <summary>
            /// Deletes a Professor and all Schedules associated with the Professor.
            /// Returns true if Professor is found and successfully deleted.
            /// </summary>
            /// <param name="professor">Professor to delete.</param>

            public bool DeleteProfessor(Professor professor)
            {
                if (professor == null) return false;
                return DeleteProfessor(professor.Name());
            }

            /// <summary>
            /// Deletes a Room and all Schedules associated with the Room.
            /// Returns true if Room is found and successfully deleted.
            /// </summary>
            /// <param name="Name">Name of the Room. [ "Building RoomNumber" ]</param>
            /// <returns></returns>

            public bool DeleteRoom(string Name)
            {
                int ind = AllRooms.BinarySearch(Name);
                if (ind < 0) return false; // room not found
                Room r = (Room)AllRooms[ind];
                ArrayList schedules = r.GetSchedules.GetArrayList;
                for (int i = 0; i < schedules.Count; ++i)
                {
                    Schedule s = (Schedule)schedules[i];
                    // delete the respective professor's schedule
                    s.GetProfessor.GetSchedules.DeleteSchedule(s);
                }
                schedules.Clear();
                r.schedules = null;
                AllRooms.RemoveAt(ind);
                return true;
            }

            /// <summary>
            /// Deletes a Room and all Schedules associated with the Room.
            /// Returns true if Room is found and successfully deleted.
            /// </summary>
            /// <param name="Building">The building where the Room is located.</param>
            /// <param name="RoomNumber">The Room number.</param>
            /// <returns></returns>

            public bool DeleteRoom(string Building, string RoomNumber)
            {
                return DeleteRoom(Building + " " + RoomNumber);
            }

            public bool DeleteRoom(Room room)
            {
                if (room == null) return false;
                return DeleteRoom(room.ToString());
            }

            /// <summary>
            /// Retrieves ArrayList of all Schedules.
            /// </summary>

            public ArrayList AllSchedules()
            {
                ArrayList scheds = new ArrayList();
                for (int i = 0; i < AllProfessors.Count; ++i)
                    scheds.AddRange(((Professor)AllProfessors[i]).GetSchedules.GetArrayList);
                return scheds;
            }

            /// <summary>
            /// Converts to array of all Schedule information.
            /// </summary>

            public string[][] ToArray()
            {
                ArrayList scheds = AllSchedules();
                string[][] AllData = new string[scheds.Count][];
                for (int i = 0; i < AllData.Length; ++i)
                {
                    Schedule s = (Schedule)scheds[i];
                    AllData[i] = s.ToArray();
                }
                return AllData;
            }

            /// <summary>
            /// Converts to array of essential Schedule information.
            /// </summary>
            /// <returns></returns>

            public string[][] ToSmallArray()
            {
                ArrayList scheds = AllSchedules();
                string[][] AllData = new string[scheds.Count][];
                for (int i = 0; i < AllData.Length; ++i)
                {
                    Schedule s = (Schedule)scheds[i];
                    AllData[i] = s.ToSmallArray();
                }
                return AllData;
            }

            

            /// <summary>
            /// Retrieves Schedule in database based on index.
            /// Returns null if index not found.
            /// </summary>
            /// <param name="index">The zero-based integer index.</param>

            public Schedule GetSchedule(int index)
            {
                int id = 0;
                foreach (Professor p in AllProfessors)
                {
                    ArrayList list = p.GetSchedules.GetArrayList;
                    if (index - id < list.Count)
                    {
                        // schedule is in current list
                        return (Schedule)list[index - id];
                    }
                    id += list.Count;
                }
                // not found
                return null;
            }


        }
    }

}

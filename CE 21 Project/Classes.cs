using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_21_Project
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

        private int rawMinutes;

        /// <summary>
        /// The integer value of total minutes of Time object.
        /// [ Monday 12:00 AM = 0 ]
        /// </summary>
        
        public int raw() { if (this == null) return 0;  return rawMinutes; }

        /// <summary>
        /// rawMinutes conversion variables
        /// </summary>

        internal static int MINUTE_MASK = 60;
        internal static int HOUR_MASK = 24 * MINUTE_MASK;
        internal static int DAY_MASK = 7 * HOUR_MASK;

        /// <summary>
        /// Minutes part of Time object.
        /// </summary>

        public int minutes(){ return rawMinutes % MINUTE_MASK; }

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
                                                                                                        /// 
        /// <summary>
        /// Array that stores the string value of the day of the week.
        /// </summary>
       
        internal static string[] DayOfWeekArray = new string[7]{ "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        
        
        /// <summary>
        /// The string value of time in military format.
        /// </summary>

        public string ToMilitaryTimeString() { return hours().ToString("D2") + ":" + minutes().ToString("D2"); }

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

        public Time(int raw) { while(raw<0) raw += DAY_MASK; rawMinutes = raw % DAY_MASK; }

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

        public Time(int day, int hr, int min) { rawMinutes = ( (day * HOUR_MASK) + (hr * MINUTE_MASK) + min ) % DAY_MASK; }

        /// <summary>
        /// Constructs a time object based on days, hours, and minutes.
        /// </summary>
        /// <param name="day">The day in string format. [ "Monday" = 0 ]</param>
        /// <param name="hr">The hour in integer format.</param>
        /// <param name="min">The minute in integer format.</param>

        public Time(string day, int hr, int min) { rawMinutes = ( (getDayOfWeek[day] * HOUR_MASK) + (hr * MINUTE_MASK) + min ) % DAY_MASK; }

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

        /// overload operators
        /// increment, decrement, add, subtract

        public static Time operator ++(Time t) { t.rawMinutes = (t.raw() + 1) % DAY_MASK; return t; }
        public static Time operator --(Time t) { t.rawMinutes = (t.raw() - 1) % DAY_MASK; return t; }
        public static Time operator + (Time t, Time t2) { return new Time(t.rawMinutes + t2.rawMinutes); }
        public static Time operator + (Time t, int t2)  { return new Time(t.rawMinutes + t2); }
        public static Time operator - (Time t, Time t2) { return new Time(t.rawMinutes - t2.rawMinutes); }
        public static Time operator - (Time t, int t2)  { return new Time(t.rawMinutes - t2); }

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
            if (obj == null) return false;
            Time t = obj as Time;
            return raw() == t.raw();
        }

    }

    /// <summmary>
    /// Stores information of a schedule.
    /// </summmary>
    
    class Schedule : IComparable
    {
        
        /// <summary>
        /// Pointer to the professor that handles the schedule.
        /// </summary>

        public Professor professor { get; set; }

        /// <summary>
        /// Pointer to the room that handles the schedule.
        /// </summary>

        public Room room { get; set; }

        /// <summary>
        /// The start time of the schedule.
        /// </summary>

        public Time StartTime { get; set; }
        
        /// <summary>
        /// The end time of the schedule.
        /// </summary>
        
        public Time EndTime { get; set; }

        /// constructors

        /// <summary>
        /// Constructs a new, empty Schedule.
        /// </summary>

        public Schedule()
        {
            professor = null;
            room = null;
            StartTime = Time.MIN_VALUE;
            EndTime = Time.MAX_VALUE;
        }

        /// <summary>
        /// Constructs a copy of another schedule.
        /// </summary>
        /// <param name="s">The schedule to copy.</param>

        public Schedule(Schedule s)
        {
            professor = s.professor;
            room = s.room;
            StartTime = s.StartTime;
            EndTime = s.EndTime;
        }

        /// <summary>
        /// Constructs a new, defined schedule.
        /// </summary>
        /// <param name="p">The pointer to the professor.</param>
        /// <param name="r">The pointer to the room.</param>
        /// <param name="start">The initial time of the schedule.</param>
        /// <param name="end">The ending time of the schedule.</param>
        
        public Schedule(Professor p, Room r, Time start, Time end)
        {
            professor = p;
            room = r;
            StartTime = start;
            EndTime = end;
        }

        /// string conversion

        /// <summary>
        /// Returns schedule information in form of a string.
        /// (For debugging purposes)
        /// </summary>

        public override string ToString()
        {
            return
                "From " + StartTime.ToString() + " To " + EndTime.ToString() + "\n\n" +
                "Professor:\n" + professor.ToString() + "\n\n" +
                "Room:\n" + room.ToString() + "\n";
        }

        /// <summary>
        /// Compares two Schedules' starting times.
        /// (negative if less, zero if equal, positive if greater)
        /// </summary>
        /// <param name="obj">The Schedule to compare.</param>
        
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Schedule s = obj as Schedule;
            if (s == null) throw new ArgumentException("Object is not an instance of Schedule");
            return StartTime.CompareTo(s.StartTime);
        }

        /// <summary>
        /// Compares the content of two Schedules.
        /// </summary>
        /// <param name="obj">The Schedule object to compare.</param>

        public override bool Equals(object obj)
        {
            Schedule s = obj as Schedule;
            if (s == null) return false;
            return StartTime.Equals(s.StartTime) && EndTime.Equals(s.EndTime) && professor.Equals(s.professor) && room.Equals(s.room);
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

        private ArrayList list;

        /// <summary>
        /// Contains the sorted list of all the schedules.
        /// </summary>
        /// <returns></returns>

        public ArrayList GetArrayList()
        {
            return list;
        }

        /// <summary>
        /// Constructs an empty ScheduleWrapper.
        /// </summary>

        public ScheduleWrapper() { list = new ArrayList();  }
        
        /// <summary>
        /// Constructs a cloned copy of another ScheduleWrapper.
        /// </summary>
        /// <param name="sw">The SchedulWrapper to copy.</param>

        public ScheduleWrapper(ScheduleWrapper sw) { list = (ArrayList) sw.list.Clone(); }

        /// conflict-checking

        /// <summary>
        /// Retrieves the integer index of (one) conflicting Schedule.
        /// Returns a negative index if no conflict is found.
        /// Note that the insertion point is the (~) of the negative return value.
        /// </summary>
        /// <param name="s">The Schedule to test for conflicts.</param>


        private int GetConflictIndex(Schedule s){

            // get bound of search based on Schedule Time

            int lowerBound = list.BinarySearch(s);
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

            if (lowerBound < list.Count )
            {
                Schedule next = (Schedule)list[lowerBound];
                if(next.StartTime.CompareTo(s.EndTime) < 0) return lowerBound;
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
        /// Returns true if schedule is inserted with no conflict, otherwise false and does not insert.
        /// </summary>
        /// <param name="s">The Schedule to insert.</param>

        public bool InsertSchedule(Schedule s)
        {
            int conflict = GetConflictIndex(s);
            if (conflict >= 0) return false;
            list.Insert(~conflict, s);
            return true;
        }

        /// <summary>
        /// Gets index of Schedule.
        /// Returns a negative number if Schedule does not exist.
        /// </summary>
        /// <param name="s">The Schedule to find</param>

        private int GetIndex(Schedule s)
        {
            int ind = GetConflictIndex(s);
            if (ind < 0) return -1;
            Schedule s2 = (Schedule)list[ind];
            if (!s.Equals(s2)) return -1;
            return ind;
        }

        /// <summary>
        /// Checks if Schedule is in the ScheduleWrapper.
        /// </summary>
        /// <param name="s">The schedule to find</param>
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

        public string LastName  { get; set; }

        /// <summary>
        /// The department of the Professor.
        /// </summary>

        public string Department{ get; set; }

        /// <summary>
        /// The name of the Professor. "LastName, FirstName"
        /// </summary>

        public string Name() { return LastName + ", " + FirstName; }

        /// <summary>
        /// The pointer to the Schedules of the Professor.
        /// </summary>

        public ScheduleWrapper Schedules;

        /// <summary>
        /// Constructs an empty Professor object.
        /// </summary>

        public Professor() { Department = "None";  Schedules = null; }

        /// <summary>
        /// Constructs a new Professor object.
        /// </summary>
        /// <param name="RawName">The name of the Professor in the format: "LastName, FirstName"</param>
        /// <param name="Dep">The department of the Professor.</param>

        public Professor(string RawName, string Dep="None")
        {
            RawName = ScheduleDatabase.NormalizeWhiteSpaces(RawName);
            int comma = RawName.IndexOf(',');
            LastName = RawName.Substring(0, comma).Trim();
            FirstName = RawName.Substring(comma + 1).Trim();
            Department = ScheduleDatabase.NormalizeWhiteSpaces(Dep);
            Schedules = new ScheduleWrapper();
        }

        /// string conversion

        /// <summary>
        /// Returns the name and the department of the Professor.
        /// </summary>
        
        public override string ToString(){ return Name() + " (" + Department + ")"; }

        /// <summary>
        /// Compares names of two Professors.
        /// (negative if less, zero if equal, positive if greater)
        /// </summary>
        /// <param name="obj">The Professor object to compare.</param>

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            string s = obj as string;
            if (s == null)
            {
                Professor x = obj as Professor;
                if (x == null) throw new ArgumentException("Object is not an instance of Professor");
                return Name().CompareTo(x.Name());
            }
            return Name().CompareTo(s);
        }

        /// <summary>
        /// Compares the content of two Professors.
        /// </summary>
        /// <param name="obj">The Professor object to compare.</param>

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Professor x = obj as Professor;
            return ToString().Equals(x.ToString());
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

        public ScheduleWrapper Schedules { get; set; }

        /// constructors

        /// <summary>
        /// Constructs an empty Room object.
        /// </summary>

        public Room() { Schedules = null; }

        public Room(string name)
        {
            name = ScheduleDatabase.NormalizeWhiteSpaces(name);
            int space = name.LastIndexOf(' ');
            RoomNumber = name.Substring(space + 1);
            Building = name.Substring(0, space);
            Schedules = new ScheduleWrapper();
        }

        /// <summary>
        /// Constructs a new Room object.
        /// </summary>
        /// <param name="building">The building where the Room is located.</param>
        /// <param name="roomnumber">The number of the Room.</param>

        public Room(string building, string roomnumber)
        {
            Building = ScheduleDatabase.NormalizeWhiteSpaces(building);
            RoomNumber = ScheduleDatabase.NormalizeWhiteSpaces(roomnumber);
            Schedules = new ScheduleWrapper();
        }

        /// string conversion
        
        /// <summary>
        /// Converts Room object to string. "Building RoomNumber"
        /// </summary>

        public override string ToString() { return Building + " " + RoomNumber; }

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
            if (obj == null) return false;
            Room r = obj as Room;
            return ToString().Equals(r.ToString());
        }



    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE_21_Project
{

    /// <summary>
    /// Stores a database of schedules of professors and rooms.
    /// </summary>

    class ScheduleDatabase
    {

        /// NormalizeWhiteSpaces:
        /// <summary>
        /// Removes contiguous sequences of whitespaces of a string.
        /// </summary>
        /// <param name="s">The string to normalize.</param>

        public static string NormalizeWhiteSpaces(string s)
        {
            int i, j, k;
            for (i = 0; i < s.Length && s[i] == ' '; ++i) ;
            for (j = s.Length - 1; j > i && s[j] == ' '; --j) ;
            StringBuilder sb = new StringBuilder();
            bool space = false;
            for (k = i; k <= j; ++k)
            {
                if (s[k] == ' ')
                {
                    if (!space)
                    {
                        sb.Append(s[k]);
                        space = true;
                    }
                }
                else
                {
                    sb.Append(s[k]);
                    space = false;
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// The list of Professors of the database.
        /// </summary>

        private ArrayList AllProfessors;

        /// <summary>
        /// The list of Rooms of the database.
        /// </summary>

        private ArrayList AllRooms;

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
        
        private static object GetData(ArrayList list, string key)
        {
            key = NormalizeWhiteSpaces(key);
            int ind = list.BinarySearch(key);
            if (ind < 0) return null;
            return list[ind];
        }

        /// <summary>
        /// Retrieves the Professor object mapped by name.
        /// Returns null if no such Professor exists.
        /// </summary>
        /// <param name="Name">The name of the professor. "LastName, FirstName"</param>
        
        public Professor GetProfessor(string Name)
        {
            return (Professor)GetData(AllProfessors, Name);
        }

        /// <summary>
        /// Retrieves the Professor object mapped by name.
        /// Returns null if no such Professor exits.
        /// </summary>
        /// <param name="Last">Surname of the Professor</param>
        /// <param name="First">First name of the Professor</param>
        /// <returns></returns>

        public Professor GetProfessor(string Last, string First)
        {
            return GetProfessor(NormalizeWhiteSpaces(Last + ", " + First));
        }

        /// <summary>
        /// Retrieves the Room object mapped by name.
        /// Returns null if no such Room exists.
        /// </summary>
        /// <param name="Name">The name of the room. "Building RoomNumber"</param>

        public Room GetRoom(string Name)
        {
            return (Room)GetData(AllRooms, Name);
        }
        
        /// AddProfessor:
        /// adds a professor indexed by name
        /// if professor already exists, the method returns professor with said name, without inserting

        /// <summary>
        /// Adds a Professor to the database.
        /// If Professor already exists, the method returns existing Professor.
        /// </summary>
        /// <param name="Name">Name of the Professor</param>
        /// <param name="Department">Department of the Professor</param>
        
        public Professor AddProfessor(string Name, string Department)
        {
            Name = NormalizeWhiteSpaces(Name);
            int ind = AllProfessors.BinarySearch(Name);
            if (ind < 0)
            {
                ind = ~ind;
                AllProfessors.Insert(ind, new Professor(Name, Department));
            }
            return (Professor)AllProfessors[ind];
        }

        /// <summary>
        /// Adds a Professor to the database.
        /// If Professor already exists, the method returns the existing Professor.
        /// </summary>
        /// <param name="LastName">Surname of the Professor</param>
        /// <param name="FirstName">First name of the Professor</param>
        /// <param name="Department">Department of the Professor</param>

        public Professor AddProfessor(string LastName, string FirstName, string Department)
        {
            return AddProfessor(LastName + ", " + FirstName, Department);
        }

        /// <summary>
        /// Adds a Room to the database.
        /// If Room already exists, the method returns the existing Room.
        /// </summary>
        /// <param name="Building">The building where the Room is located.</param>
        /// <param name="RoomNumber">The room number.</param>
        /// <returns></returns>

        public Room AddRoom(string Building, string RoomNumber)
        {
            string Name = NormalizeWhiteSpaces(Building + " " + RoomNumber);
            int ind = AllRooms.BinarySearch(Name);
            if (ind < 0)
            {
                ind = ~ind;
                AllRooms.Insert(ind, new Room(Building, RoomNumber));
            }
            return (Room)AllRooms[ind];
        }

        /// <summary>
        /// Adds a Room to the database.
        /// If Room already exists, the method returns the existing Room.
        /// </summary>
        /// <param name="Name">The name of the classroom. "Building RoomNumber"</param>

        public Room AddRoom(string Name)
        {
            Name = NormalizeWhiteSpaces(Name);
            int space = Name.LastIndexOf(' ');
            return AddRoom(Name.Substring(0, space), Name.Substring(space + 1));
        }

        /// conflict checking

        /// <summary>
        /// Returns a conflicting Schedule in the database.
        /// Returns null if no conflict is found.
        /// </summary>
        /// <param name="s">The Schedule to test for conflicts.</param>

        public Schedule GetConflict(Schedule s)
        {
            Schedule conflict = s.professor.Schedules.GetConflict(s);
            if (conflict == null)
                conflict = s.room.Schedules.GetConflict(s);
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
            if(HasConflict(s)) return false;
            s.professor.Schedules.InsertSchedule(s);
            s.room.Schedules.InsertSchedule(s);
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

        public bool InsertSchedule(Professor p, Room r, Time start, Time end)
        {
            Schedule s = new Schedule { StartTime = start, EndTime = end, professor = p, room = r };
            return InsertSchedule(s);
        }

        /// <summary>
        /// Deletes a Schedule.
        /// Returns true if Schedule is successfully deleted.
        /// </summary>
        /// <param name="s">Schedule to delete.</param>

        public bool DeleteSchedule(Schedule s)
        {
            if (s.professor.Schedules.Contains(s) && s.room.Schedules.Contains(s))
            {
                s.professor.Schedules.DeleteSchedule(s);
                s.room.Schedules.DeleteSchedule(s);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Deletes a Professor and all Schedules associated with the Professor.
        /// Returns true if Professor is found and successfully deleted.
        /// </summary>
        /// <param name="Name">Name of the Professor "LastName, FirstName"</param>
        /// <returns></returns>

        public bool DeleteProfessor(string Name)
        {
            Name = NormalizeWhiteSpaces(Name);
            int ind = AllProfessors.BinarySearch(Name);
            if (ind < 0) return false; // professor not found
            Professor x = (Professor)AllProfessors[ind];
            ArrayList schedules = x.Schedules.GetArrayList();
            for (int i = 0; i < schedules.Count; ++i)
            {
                Schedule s = (Schedule)schedules[i];
                // delete the respective room's schedule
                s.room.Schedules.DeleteSchedule(s);
            }
            schedules.Clear();
            AllProfessors.RemoveAt(ind);
            return true;
        }

        /// <summary>
        /// Deletes a Professor and all Schedules associated with the Professor.
        /// Returns true if Professor is found and successfully deleted.
        /// </summary>
        /// <param name="LastName">Surname of the Professor</param>
        /// <param name="FirstName">First name of the Professor</param>

        public bool DeleteProfessor(string LastName, string FirstName)
        {
            return DeleteProfessor(LastName + ", " + FirstName);
        }

        /// <summary>
        /// Deletes a Room and all Schedules associated with the Room.
        /// Returns true if Room is found and successfully deleted.
        /// </summary>
        /// <param name="Building">The building where the room is located</param>
        /// <param name="RoomNumber">The room number</param>
        /// <returns></returns>

        public bool DeleteRoom(string Building, string RoomNumber)
        {
            string Name = NormalizeWhiteSpaces(Building + " " + RoomNumber);
            int ind = AllRooms.BinarySearch(Name);
            if (ind < 0) return false; // room not found
            Room r = (Room)AllRooms[ind];
            ArrayList schedules = r.Schedules.GetArrayList();
            for (int i = 0; i < schedules.Count; ++i)
            {
                Schedule s = (Schedule)schedules[i];
                // delete the respective professor's schedule
                s.professor.Schedules.DeleteSchedule(s);
            }
            schedules.Clear();
            AllRooms.RemoveAt(ind);
            return true;
        }

        /// <summary>
        /// Deletes a Room and all Schedules associated with the Room.
        /// Returns true if Room is found and successfully deleted.
        /// </summary>
        /// <param name="Name">Name of the Room "Building RoomNumber"</param>
        /// <returns></returns>

        public bool DeleteRoom(string Name)
        {
            Name = NormalizeWhiteSpaces(Name);
            int space = Name.LastIndexOf(' ');
            return DeleteRoom(Name.Substring(0, space), Name.Substring(space + 1));
        }

    }
}

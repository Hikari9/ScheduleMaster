using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleMaster
{
    namespace Classes
    {
        abstract class Base
        {
            protected Dictionary<string, object> Info;
            public object this[string key]
            {
                get
                {
                    if (!Info.ContainsKey(key)) return null;
                    return Info[key];
                }
                set
                {
                    if (!Info.ContainsKey(key)) Info.Add(key, value);
                    else Info[key] = value;
                }
            }
            public static string[] Headers;
        }
        partial class Subject : Base
        {
            public static string[] Headers = new string[]{
                "Title"
            };

            public Subject()
            {
                Info = new Dictionary<string, object>();
            }
        }
        partial class Professor : Base
        {
            public static string[] Headers = new string[]{
                "Last Name", "First Name", "ID Number", "Contact Info"
            };
            public Professor()
            {
                Info = new Dictionary<string, object>();
            }
        }
        partial class Room : Base
        {
            public static string[] Headers = new string[]{
                "Name"
            };
            public Room()
            {
                Info = new Dictionary<string, object>();
            }
        }
        partial class Schedule
        {
        }
    }
}

#include<iostream>
#include<iomanip>
#include<sstream>
#include<fstream>
#include<vector>
#include<map>
#include<set>
#include<cstdio>
#include<cstring>
#include<cctype>
#include<algorithm>

using namespace std;
class Schedule;
class Professor;
class Room;
class Name;
class Time;
istream& operator>>( istream&, Schedule& );
istream& operator>>( istream&, Professor& );
istream& operator>>( istream&, Room& );
istream& operator>>( istream&, Name& );
istream& operator>>( istream&, Time& );
ostream& operator<<( ostream&, const Schedule& );
ostream& operator<<( ostream&, const Professor& );
ostream& operator<<( ostream&, const Room& );
ostream& operator<<( ostream&, const Name& );
ostream& operator<<( ostream&, const Time& );
namespace formatter{
	string lowercase( string s ){
		transform( s.begin(), s.end(), s.begin(), ::tolower );
		return s;
	}
	string uppercase( string s ){
		transform( s.begin(), s.end(), s.begin(), ::toupper );
		return s;
	}
	string capitalize( const string& s ){
		istringstream in(s);
		ostringstream out;
		string buf;
		bool f = false;
		// stream through words, remove extra spaces
		while( in >> buf ){
			// transform everything to lowercase first
			buf = lowercase(buf);
			buf[0] = toupper(buf[0]);
			if(f) out << ' ';
			else f=true;
			out << buf;
		}
		return out.str();
	}
	
}
class Name{
	private:
	/// containers (private)
		string last, first, middle, suff;
			// middle may be middle initial
			// suff can be PHD, JR, III
	public:
	/// accessors
		string firstName()const{ return first; }
		string middleName()const{ return first; }
		string lastName()const{ return first; }
		string suffix()const{ return first; }
	/// constructors
	// default constructor
		Name(): last(), first(), middle(), suff() {}
	// copy constructor
		Name( const Name& _ ): first(_.first), middle(_.middle), last(_.last), suff(_.suff) {}
	// Name( "Juan", "B.", "Dela Cruz" )
		Name( const string& f, const string& m, const string& l, const string& s = string() ): first(f), middle(m), last(l), suff(s) { capitalize(); }
	// from formal string, delimited by comma(,)
		Name( const char* s ){
			istringstream in(s);
			getline( in, last, ',' );
			getline( in, first, ',' );
			getline( in, middle, ',' );
			getline( in, suff, ',' );
			capitalize();
		}
		Name( const string& s ){
			istringstream in(s);
			getline( in, last, ',' );
			getline( in, first, ',' );
			getline( in, middle, ',' );
			getline( in, suff, ',' );
			capitalize();
		}
	/// public methods
		string toFormalString()const{ return last + ", " + first + " " + middle; }
		string toString()const{
			string s = first + " " + middle + " " + last;
			if( !suff.empty() ) s.append(", ").append(suff);
			return s;
		}
	/// comparators
		int compareTo( const Name& _ )const{
			int cmp = last.compare( _.last );
			if( !cmp ){
				cmp = first.compare( _.first );
				if( !cmp ){
					cmp = middle.compare( _.middle );
					if( !cmp ){
						cmp = suff.compare( _.suff );
					}
				}
			}
			return cmp;
		}
		bool operator< ( const Name& _ )const{ return compareTo(_)<0; }
		bool operator> ( const Name& _ )const{ return compareTo(_)>0; }
		bool operator==( const Name& _ )const{ return compareTo(_)==0; }
		bool operator!=( const Name& _ )const{ return compareTo(_)!=0; }
		bool operator<=( const Name& _ )const{ return compareTo(_)<=0; }
		bool operator>=( const Name& _ )const{ return compareTo(_)>=0; }
	private:
		void capitalize(){
			first = formatter::capitalize(first);
			middle = formatter::capitalize(middle);
			last = formatter::capitalize(last);
			suff = formatter::uppercase(suff);
			if( middle.empty() ) middle = ".";
		}
};
class Time{
	public:
	/// containers(public)
		int totalMinutes;
		static string dayOfTheWeek[8];
	/// constructors
		Time(): totalMinutes(0) {}
		Time( const Time& _ ): totalMinutes(_.totalMinutes) {}
		Time( const string& _ ){
			int day, hr, min;
			sscanf( _.c_str(), "%d:%d:%d", &day, &hr, &min );
			totalMinutes = min+hr*60+day*1440;
		}
		Time( const char* c ){
			int day, hr, min;
			sscanf( c, "%d:%d:%d", &day, &hr, &min );
			totalMinutes = min+hr*60+day*1440;
			totalMinutes = min+hr*60+day*1440;
		}
		Time( int t ): totalMinutes(t) {}
		Time( int day, int hr, int min ): totalMinutes( min+hr*60+day*1440 ) {}
		Time( const string& day, int hr, int min ): totalMinutes( min+hr*60+(find(dayOfTheWeek+1,dayOfTheWeek+8,formatter::capitalize(day))-dayOfTheWeek)*1440 ) {}
	/// accessors
		int days()const{ return totalMinutes/1440; }
		int hours()const{ return (totalMinutes/60)%24; }
		int minutes()const{ return totalMinutes%60; }
		string toString()const{
			ostringstream out;
			out << days() << " day/s " << setw(2) << setfill('0') << hours() << " hour/s " << setw(2) << setfill('0') << minutes() << " minute/s";
			return out.str();
		}
		
	/// comparators
		int compareTo( const Time& _ )const{ return totalMinutes - _.totalMinutes; }
		bool operator< ( const Time& _ )const{ return compareTo(_)<0; }
		bool operator> ( const Time& _ )const{ return compareTo(_)>0; }
		bool operator==( const Time& _ )const{ return compareTo(_)==0; }
		bool operator!=( const Time& _ )const{ return compareTo(_)!=0; }
		bool operator<=( const Time& _ )const{ return compareTo(_)<=0; }
		bool operator>=( const Time& _ )const{ return compareTo(_)>=0; }
	/// arithmetics
		Time& operator++(){ ++totalMinutes; return *this; }
		Time& operator--(){ ++totalMinutes; return *this; }
		Time operator++( int _ ){ Time COPY(*this); operator++(); return COPY; }
		Time operator--( int _ ){ Time COPY(*this); operator--(); return COPY; }
		Time operator+( const Time& _ )const{ return totalMinutes+_.totalMinutes; }
		Time operator-( const Time& _ )const{ return totalMinutes-_.totalMinutes; }
		Time operator*( const Time& _ )const{ return totalMinutes*_.totalMinutes; }
		Time operator/( const Time& _ )const{ return totalMinutes/_.totalMinutes; }
		Time operator%( const Time& _ )const{ return totalMinutes%_.totalMinutes; }
		Time& operator+=( const Time& _ ){ totalMinutes+=_.totalMinutes; return *this; }
		Time& operator-=( const Time& _ ){ totalMinutes-=_.totalMinutes; return *this; }
		Time& operator*=( const Time& _ ){ totalMinutes*=_.totalMinutes; return *this; }
		Time& operator/=( const Time& _ ){ totalMinutes/=_.totalMinutes; return *this; }
		Time& operator%=( const Time& _ ){ totalMinutes%=_.totalMinutes; return *this; }
};
// contains weekly schedule
class Schedule{
	// private:
	public:
		/// static functions for conflict checking
		template<class Type1, class Type2>
		static bool pairCompare( const pair<Type1,Type2>&, const pair<Type1,Type2>& );
		static bool conflicts( const Schedule&, const Schedule& );
		struct pointerCompare{
			bool operator()( const Schedule* lhs, const Schedule* rhs )const{
				return *lhs<*rhs;
			}
		};

	public:
		/// members
		const Professor* prof;
		const Room* room;
		Time start, end;
		// time duration
		Time length()const{ return end-start; }
		/// constructors
		Schedule(): prof(NULL), room(NULL), start(0), end(0) {}
		Schedule( const Schedule& _ ): prof(_.prof), room(_.room), start(_.start), end(_.end) {}
		Schedule( const Time& a, const Time& b, const Professor* P = NULL, const Room* R = NULL ): start(a), end(b), prof(P), room(R) {
			if( length()<0 ) swap(start,end);
			else if( length()==0 ) cerr << "Warning: Zero time schedule" << endl;
		}
		string toString()const;
		bool operator<( const Schedule& _ )const{
			if( Schedule::conflicts(*this,_) ) return false;
			return start < _.start;
		}
		
};
class Room{
	public:
		/// schedule reference container
		set<Schedule*,Schedule::pointerCompare>* sched;
	public:
		/// static mapping of buildings to building code
		static pair<string,string> rawBuildingCodes[];
		static map<string,string> buildingCode;
		/// public members
		string building, roomNumber;
		Room(): building(), sched(new set<Schedule*,Schedule::pointerCompare>), roomNumber() {}
		Room( const Room& _ ): building(_.building), sched(_.sched), roomNumber(_.roomNumber) {}
		Room( const string& b, const string& r ): building(b), roomNumber(r), sched(new set<Schedule*,Schedule::pointerCompare>) {}
		string toString()const{ return building + " " + roomNumber; }
		void printSchedules( ostream& out = cout )const{
			set<Schedule*,Schedule::pointerCompare>::iterator it;
			out << toString() << endl;
			for( it=sched->begin(); it!=sched->end(); ++it ) out << (**it).toString() << endl;
			out << endl;
		}
		string toCode()const{ return buildingCode[building] + " " + roomNumber; }
		int compareTo( const Room& _ )const{
			int cmp = building.compare(_.building);
			if( !cmp )
				cmp = roomNumber.compare(_.roomNumber);
			return cmp;
		}
		bool operator< ( const Room& _ )const{ return compareTo(_)<0; }
		bool operator> ( const Room& _ )const{ return compareTo(_)>0; }
		bool operator==( const Room& _ )const{ return compareTo(_)==0; }
		bool operator!=( const Room& _ )const{ return compareTo(_)!=0; }
		bool operator<=( const Room& _ )const{ return compareTo(_)<=0; }
		bool operator>=( const Room& _ )const{ return compareTo(_)>=0; }
};
class Professor{
	public:
		/// schedule reference container
		set<Schedule*,Schedule::pointerCompare>* sched;
	public:
		/// public members
		string department;
		Name name;
		/// constructors
		Professor(): department(), sched( new set<Schedule*,Schedule::pointerCompare> ), name() {}
		Professor( const Professor& _ ): sched(_.sched), name(_.name), department(_.department) {}
		Professor( const Name& n, const string& dep = string() ): department(dep), name(n), sched(new set<Schedule*,Schedule::pointerCompare>) {}
		/// accessors
		string toString()const{
			return name.toString() + " (" + department + ")";
		}
		void printSchedules( ostream& out = cout )const{
			set<Schedule*,Schedule::pointerCompare>::iterator it;
			out << toString() << endl;
			for( it=sched->begin(); it!=sched->end(); ++it ) out << (**it).toString() << endl;
			out << endl;
		}
		/// comparators
		int compareTo( const Professor& _ )const{
			int cmp = name.compareTo(_.name);
			if( !cmp )
				cmp = department.compare(_.department);
			return cmp;
		}
		bool operator< ( const Professor& _ )const{ return compareTo(_)<0; }
		bool operator> ( const Professor& _ )const{ return compareTo(_)>0; }
		bool operator==( const Professor& _ )const{ return compareTo(_)==0; }
		bool operator!=( const Professor& _ )const{ return compareTo(_)!=0; }
		bool operator<=( const Professor& _ )const{ return compareTo(_)<=0; }
		bool operator>=( const Professor& _ )const{ return compareTo(_)>=0; }
};
string Schedule::toString()const{
	ostringstream out;
	// assume that start day = end day
	out << "(" << Time::dayOfTheWeek[ start.days() ] << ") " << setw(2) << setfill('0') << start.hours() << ":" << setw(2) << setfill('0') << start.minutes() << " - " << setw(2) << setfill('0') << end.hours() << ":" << setw(2) << setfill('0') << end.minutes() << endl;
	out << room->toString() << " - " << prof->toString();
	return out.str();
}
string Time::dayOfTheWeek[8] = { "", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
template<class Type1, class Type2>
bool Schedule::pairCompare( const pair<Type1,Type2>& lhs, const pair<Type1,Type2>& rhs ){
	return lhs.first<rhs.first || ( lhs.first==rhs.first && lhs.second<rhs.second );
}
bool Schedule::conflicts( const Schedule& lhs, const Schedule& rhs ){
	pair<Time,int> p[4] = {
		make_pair( lhs.start, 2 ),
		make_pair( lhs.end, -2 ),
		make_pair( rhs.start, 1 ),
		make_pair( rhs.end, -1 )
	};
	sort( p, p+4, pairCompare<Time,int> );
	return !(p[1].second<0 && p[2].second>0 && p[1].second+p[2].second!=0);
}

pair<string,string> Room::rawBuildingCodes[] = {
	// make_pair( "Faura", "F" ),
	// make_pair( "Berchmans", "B" ),
	// make_pair( "Schmitt", "C" ),
	// make_pair( "SEC A", "SECA" ),
	// make_pair( "SEC B", "SECB" ),
	// make_pair( "SEC C", "SECC" ),
	// make_pair( "MVP", "MVP" ),
	// make_pair( "Bellarmine", "BEL" ),
	// make_pair( "Social Sciences", "SS" ),
	// ... add more here
};
map<string,string> Room::buildingCode( Room::rawBuildingCodes, Room::rawBuildingCodes+sizeof(Room::rawBuildingCodes)/sizeof(pair<string,string>) );

istream& operator>>( istream&, Schedule& );
istream& operator>>( istream&, Professor& );
istream& operator>>( istream&, Room& );
istream& operator>>( istream&, Name& );
istream& operator>>( istream&, Time& );
ostream& operator<<( ostream&, const Schedule& );
ostream& operator<<( ostream& out, const Professor& _ ){ return out << _.toString(); }
ostream& operator<<( ostream& out, const Room& _ ){ return out << _.toString(); }
ostream& operator<<( ostream& out, const Name& _ ){ return out << _.toString(); }
ostream& operator<<( ostream& out, const Time& _ ){ return out << _.toString(); }

set<Professor> allProfessors;
set<Room> allRooms;

bool insertSchedule( Professor prof, Room room, Time a, Time b ){
	const Professor* x = &*allProfessors.insert(prof).first;
	const Room* r = &*allRooms.insert(room).first;
	Schedule* s = new Schedule( a, b, x, r );
	if( x->sched->count(s)==1 ){
		cerr << endl;
		cerr << "Error: Schedule conflict with Professor's time" << endl << endl;
		cerr << "tries to insert" << endl << s->toString() << endl << endl;
		cerr << "conflicts with" << endl << (*x->sched->find(s))->toString() << endl << endl;
		return false;
	}
	if( r->sched->count(s)==1 ){
		cerr << endl;
		cerr << "Error: Schedule conflict with Room" << endl << endl;
		cerr << "tries to insert" << endl << s->toString() << endl << endl;
		cerr << "conflicts with" << endl << (*r->sched->find(s))->toString() << endl << endl;
		return false;
	}
	x->sched->insert(s);
	r->sched->insert(s);
	return true;
}
int main(){
	Name name;
	string buf;
	string dep, building, roomNumber, day;
	int hr1, hr2, min1, min2;
	ifstream fin( "save.txt" );
	while( fin.good() ){
		getline( fin, buf );
		name = Name(buf);
		getline( fin, buf );
		dep = buf;
		getline( fin, buf );
		reverse( buf.begin(), buf.end() );
		{
			istringstream in(buf);
			in >> roomNumber;
			building.clear();
			while( in >> buf ){
				if( !building.empty() ) building.append(" ");
				building.append(buf);
			}
		}
		reverse( building.begin(), building.end() );
		reverse( roomNumber.begin(), roomNumber.end() );
		getline( fin, day );
		getline( fin, buf );
		sscanf( buf.c_str(), "%d:%d - %d:%d", &hr1, &min1, &hr2, &min2 );
		insertSchedule( Professor(name, dep), Room( building, roomNumber ), Time( day, hr1, min1 ), Time( day, hr2, min2 ) );
		fin.ignore();
	}
	ofstream fout( "save.txt", ofstream::app );
	
	while(cin.good()){
		
		cout << "Insert new schedule" << endl << endl;
		cout << "Enter professor's name ( e.g. Lao, Bryan, T. ):" << endl;
		getline( cin, buf );
		name = Name(buf);
		cout << "Enter department ( e.g. ECCE ):" << endl;
		getline( cin, buf );
		dep = buf;
		cout << "Enter classroom ( e.g. CTC 219 ):" << endl;
		getline( cin, buf );
		reverse( buf.begin(), buf.end() );
		{
			istringstream in(buf);
			in >> roomNumber;
			building.clear();
			while( in >> buf ){
				if( !building.empty() ) building.append(" ");
				building.append(buf);
			}
		}
		reverse( building.begin(), building.end() );
		reverse( roomNumber.begin(), roomNumber.end() );
		cout << "Enter day of the week ( e.g. Monday ):" << endl;
		getline( cin, day );
		cout << "Enter timeframe ( e.g. 13:30 - 14:30 ):" << endl;
		getline( cin, buf );
		sscanf( buf.c_str(), "%d:%d - %d:%d", &hr1, &min1, &hr2, &min2 );
		
		if( insertSchedule( Professor(name, dep), Room( building, roomNumber ), Time( day, hr1, min1 ), Time( day, hr2, min2 ) ) ){
			cout << endl << "Insertion successful" << endl << endl;
			cout << "Name         : " << name << endl;
			cout << "Department   : " << dep << endl;
			cout << "Classroom    : " << building << " " << roomNumber << endl;
			cout << "Time Start   : " << setw(2) << setfill('0') << hr1 << ":" << setw(2) << setfill('0') << min1 << " (" << day << ")" << endl;
			cout << "Time End     : " << setw(2) << setfill('0') << hr2 << ":" << setw(2) << setfill('0') << min2 << " (" << day << ")" << endl;
			cout << endl;
			fout << name.toFormalString() << endl;
			fout << dep << endl;
			fout << building << " " << roomNumber << endl;
			fout << day << endl;
			fout << setw(2) << setfill('0') << hr1 << ":" << setw(2) << setfill('0') << min1 << 
			" - " << setw(2) << setfill('0') << hr2 << ":" << setw(2) << setfill('0') << min2 << endl;
			fout << endl;
		}
		else
			cout << "Insertion failed" << endl << endl;
		getline( cin, buf );
		
	}
	
	
}

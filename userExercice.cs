using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;

class User{
public int Id{ get; set; }
public string Name { get; set; }
public int Age{ get; set; }
public string City{ get; set; }

public User(int id,string name ,int age,string city){
	this.Id =id;
	this.Name =name;
	this.Age=age;
	this.City= city;
}

}


class App{
static Action<string> printf = Console.Write;
static Func<string> input = ()=> Console.ReadLine() ?? "";
static Action<string, ConsoleColor> print = (msg, color) =>
{
    Console.ForegroundColor = color;
    Console.WriteLine(msg);
    Console.ResetColor();
};


static List<User> AddPerson(List<User> users ,int id, string name , int age,string city){
	users.Add(new User(id ,name,age,city));
	return users;
}

static void display(List<User> users ){
	foreach(var person in users){
	printf($"Name : {person.Name} , Age : {person.Age} , city : {person.City}\n");
}
}

static void search(List<User> users ,string aname){
	var user =users.FirstOrDefault(u=> u.Name == aname);
	if(user!=null){
		user.Age = 22;
		print($"User {aname} found and updated to age {user.Age}", ConsoleColor.Cyan);
	}
	else {print($"user with name {aname} not found",ConsoleColor.Red);}
}
static void Main(){

var user = new List<User>{
new User(1,"tarek",18, "tlemcen"),
new User(2,"ahmed",21,"alger center"),

};

user = AddPerson(user,3,"titi",26,"cairo");

printf("enter name : ");
string name = input();
search(user,name);
display(user);



}


}
  

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using MyBook;

/*
book class
		public int bookId{get;set;}
        public string bookTitle{get;set;} = string.Empty;
        public string bookAuthor{get;set;} =string.Empty;
        public string bookYear{get;set;}=string.Empty;

*/
class App{
static Action<string> printf = Console.Write;
static Func<string> input = ()=> Console.ReadLine() ?? "";
static Action<string, ConsoleColor> print = (msg, color) =>
{
    Console.ForegroundColor = color;
    Console.WriteLine(msg);
    Console.ResetColor();
};


//Add Book

static void addBook(List<Book> book,int id,string title,string author, string year){
book.Add(new Book( id, title, author,  year));
print($"book with id : {id} added successfully ;)\n",ConsoleColor.Green);
}

//DisplayBooks
static void DisplayBooks(List<Book> book){
	foreach(var b in book){
		printf($"id : {b.bookId} , Author by : {b.bookAuthor}\n");
	}
}

//SearchBook

static void SearchBook(List<Book> book ,string name){
	var mybook = book.FirstOrDefault(b=> string.Equals(b.bookTitle,name,StringComparison.OrdinalIgnoreCase));
	if(mybook!=null){
		print("the book exist. \n",ConsoleColor.Green);
	}
	else{
		print($"book with title {name} does not exist. \n",ConsoleColor.Red);
	}
}




static void Main(){
 var books = new List<Book>{
	new Book(1,"book1","Mr.dolve","2002"),
	new Book(2,"book2","Mme.selver","2003"),
};

addBook(books,3,"book3","Mr.sind","2025");
//SearchBook(books,"book1");
DisplayBooks(books);
}


}
  

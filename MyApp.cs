using System;
using System.Collections.Generic;
using myTable;

class App {
	static Action<string> printf = Console.Write;
	static Func<string> input = ()=> Console.ReadLine() ?? "";

//display table

	static void displayTables(List<Table> tables) {
		if(tables.Count() == 0) {
			printf("there is no tables !");
			return;
		}
		printf("\n-------- List of Tables --------\n");
		foreach(Table t in tables) {
			printf($"\nTable id: {t.Id} , name:{t.Name}");
		}
		printf("\n--------------------------------\n");
	}

	static void displayTableById(List<Table> tables,int id) {
		Table table =tables.FirstOrDefault(t=> t.Id == id);
		if(tables == null) {
			printf($"id:{id} does not exist! \n");
			return;
		}
		if(id >tables.Count() || id<0) {
			printf($"id:{id} does not exist! \n");
			return;
		}

		if(table.Rows == null || table.Rows.Count == 0) {
			printf($"Table ID {id} exists but has no data.");
			return;
		}
		else {
			printf($"\n--List of Table with ID:{id} --\n");
			foreach(var row in table.Rows) {
				for(int i=0; i<row.Data.Length; i++) {

					printf($"Product {i + 1}: {row.Data[i]} \n");
				}
			}
			printf("\n--------------------------------\n");
		}


	}


	static void RemoveTable(List<Table> tables,int id) {
		Table table =tables.FirstOrDefault(t=> t.Id == id);
		if(tables == null) {
			printf($"id:{id} does not exist! \n");
			return;
		}
		if(id<0 || id >tables.Count()) {
			printf($"id:{id} does not exist! \n");
			return;
		}
		if(id<=tables.Count() ||  id>=0) {
			tables.RemoveAt(id);
			printf($"\ntable with id {id} is successfully deleted !\n");
		}
		else printf($"table with id {id} does not exist !");

	}


//create table
	static Table createTable(int id,int id_Row) {
		string name;
		int size;
		string element;
		printf("enter name of the table :");
		name = input();
		Table t = new Table{Id = id, Name=name};
		printf("enter the number of elements :");
		while(!int.TryParse(input(),out size)) {
			printf("enter a valide number of elements !\n");
			printf("enter the number of elements :");
		}
		string[] data = new string[size];
		for(int i=0; i<size; i++) {
			printf($"\n element {i} :");
			element = input();
			data[i] = element;
		}
		t.Rows.Add(new Row{rowID = id_Row, Data = data});

		return t;
	}


//show menu
	static void Menu(string name) {

		printf("\n	 ------- Menu -------\n\n");
		int i =1;
		printf($"\t {i++}. Add a new table \n");
//printf($"\t {i++}. Add data to a table \n");
		printf($"\t {i++}. View all tables\n");
		printf($"\t {i++}. Find a table by ID\n");
		printf($"\t {i++}. Remove a table\n");
		printf($"\t {i++}. Exit the system\n\n");
	}




	static void Main() {

//variables
		string name;
		int choice;
		int Ud=0, Ud_Row=0;
		int table_id;
		List<Table> tables = new List<Table>();
//define a list of tables
//create a table
//Display All Tables and Their Rows

//-------------------------

		do {
			printf("enter your name :");
			name= "tarek";// input();
		} while(name.Length ==0);

		printf($"\t Welcome Mr/Mme. {name}\n  ");

		do {
			Menu(name);
			printf("\n enter choice : ");
			while(!int.TryParse(input(), out choice) || choice>6 || choice<0) {
				printf("Invalid choice! Try again: ");
			}


//choose over the menu
			switch(choice) {
			case 1: // create a table
				tables.Add(createTable(Ud, Ud_Row));
				Ud++;
				Ud_Row++;
				break;

			case 2: //view all tables
				displayTables(tables);
				break;

			case 3: //view table by Id
				printf("enter an id :");
				while(!int.TryParse(input(), out table_id)) {
					printf("invalide id !\n");
					printf("enter an id :");
				}
				displayTableById(tables,table_id);
				break;

			case 4:
				printf("enter id to remove  :");
				while(!int.TryParse(input(), out table_id)) {
					printf("invalide id !\n");
					printf("enter an id :");
				}
				RemoveTable(tables,table_id);

				break;
			case 5:
				printf("logout !");
				break;
			}
		} while(choice !=5);


	}
}


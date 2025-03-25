//create a name Space and table classa and row class
using System.Collections.Generic;

namespace myTable{

public class Table{
    public int Id {get;set;}
    public string Name {get;set;}
    public List<Row> Rows {get;set;}

    public Table(){
        Rows = new List<Row>();
}
}
public class Row{
    public int rowID  {get;set;}
    public string[] Data  {get;set;}

    public Row(){
        Data = new string[0];
    }
}



}

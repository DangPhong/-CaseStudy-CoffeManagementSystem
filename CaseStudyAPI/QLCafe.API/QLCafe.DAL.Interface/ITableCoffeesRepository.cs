using QLCafe.Domain.Requets;
using QLCafe.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLCafe.DAL.Interface
{
    public interface ITableCoffeesRepository
    {
        IList<TableCoffees> TableCoffeesGetAll();
        int TableCoffeesAddToBook(TableCoffeesAddToBook Requets);
        TableCoffees TableCoffeesGetByID(int Id);
        TableCoffeesDetail TableCoffeesDetail(int Id);
        bool TableCoffeesAdd(TableCoffeesAdd Requets);
        bool TableCoffeesUpdate(TableCoffeesUpdate Requets);
        bool TableCoffeesAddByID(TableCoffeesAddByID Requets);
        int TableCoffeesDelete(int Id);
        IList<TableCoffees> TableCoffeesGetBookedATable();
        IList<TableCoffees> TableCoffeesGetByIdArea(int Id);
        IList<TableCoffees> TableCoffeesGetEmptyTable();
        IList<TableCoffees> TableCoffeesGetNotEmptyTable();
        bool TableCoffeesToCanBook(int Id);
        
    }
}

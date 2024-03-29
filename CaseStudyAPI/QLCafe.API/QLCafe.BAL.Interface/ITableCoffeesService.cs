﻿using QLCafe.Domain.Requets;
using QLCafe.Domain.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace QLCafe.BAL.Interface
{
    public interface ITableCoffeesService
    {
        IList<TableCoffees> TableCoffeesGetAll();
        int TableCoffeesAddToBook(TableCoffeesAddToBook Requets);
        TableCoffees TableCoffeesGetByID(int Id);
        TableCoffeesDetail TableCoffeesDetail(int Id);
        bool TableCoffeesAdd(TableCoffeesAdd Requets);
        bool TableCoffeesUpdate(TableCoffeesUpdate Requets);
        bool TableCoffeesAddByID(TableCoffeesAddByID Requets);
        bool TableCoffeesDelete(int Id);
        IList<TableCoffees> TableCoffeesGetBookedATable();
        IList<TableCoffees> TableCoffeesGetByIdArea(int Id);
        IList<TableCoffees> TableCoffeesGetEmptyTable();
        IList<TableCoffees> TableCoffeesGetNotEmptyTable();
        bool TableCoffeesToCanBook(int Id);
    }
}

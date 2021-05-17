using Model;
using System;
using System.Collections;
using System.Data;
using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Control
{
    public class ControlRelatorios
    {
        ModelRelatorios relatorios;
        public DateTime reportDate { get; private set; }
        public DateTime startDate { get; private set; }
        public DateTime endDate { get; private set; }
        public List<SaleListing> saleList { get; private set; }
        public List<NetSaleByPeriod> netSaleByPeriod { get; private set; }
        public double totalNetSales { get; private set; }

        public void DashboardDados(EntitiesRelatorio obj)
        {
            relatorios = new ModelRelatorios();
            relatorios.GraficoCategorias(obj);
            relatorios.GraficoProdutos(obj);
            relatorios.DashBoardDados(obj);
            relatorios.GraficoVendas(obj);

        }



        public void createSalesOrderReport(DateTime fromDate, DateTime toDate)
        {
            //implement dates
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;
           
            //create seles listing
            relatorios = new ModelRelatorios();
            var result = relatorios.Vendas(fromDate, toDate);
            saleList = new List<SaleListing>();



            foreach(DataRow row in result.Rows)
            {
                var salesModel = new SaleListing()
                {
                   

                    ID_Venda = Convert.ToInt32(row[0]),
                    DT_Venda = Convert.ToDateTime(row[1]),
                    NM_Cliente = Convert.ToString(row[2]),
                    NM_Funcionario = Convert.ToString(row[3]),
                    NM_Produto = Convert.ToString(row[4]),
                    VL_Total = Convert.ToString(row[5]),
                    VL_TotalD = Convert.ToDouble(row[5]),
                    VL_Custo = Convert.ToString(row[6]),
                   

                };


             
                    saleList.Add(salesModel);

                // calculate total net sales
                totalNetSales += Convert.ToDouble(row[5]);
            }

            

            //create net sales by period
            //create temp list net sales by date
            var listSalesByDate = (from sales in saleList
                                   group sales by sales.DT_Venda
                                   into listSales
                                   select new
                                   {
                                       date = listSales.Key,
                                       amount = listSales.Sum(item => item.VL_TotalD)

                                   }).AsEnumerable();

            int totalDays = Convert.ToInt32((toDate - fromDate).Days);

            //group period by days

            if(totalDays <= 7)
            {
                netSaleByPeriod = (from sales in listSalesByDate
                                   group sales by sales.date.ToString("dd-MMM-yyyy")
                                   into listSales
                                   select new NetSaleByPeriod
                                   {
                                       periodo = listSales.Key,
                                       netSales = listSales.Sum(item => item.amount)


                                   }).ToList();
            }

            //group period by week

            else if (totalDays <= 30)
            {
                netSaleByPeriod = (from sales in listSalesByDate
                                   group sales by 
                                   System.Globalization.CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(
                                       sales.date, System.Globalization.CalendarWeekRule.FirstDay,DayOfWeek.Monday)
                                   into listSales
                                   select new NetSaleByPeriod
                                   {
                                       periodo =  "Semana   " + listSales.Key.ToString(),
                                       netSales = listSales.Sum(item => item.amount)


                                   }).ToList();
            }

            //group period by months

            else if (totalDays <= 365)
            {
                netSaleByPeriod = (from sales in listSalesByDate
                                   group sales by sales.date.ToString("MMM-yyyy")
                                    into listSales
                                   select new NetSaleByPeriod
                                   {
                                       periodo = listSales.Key,
                                       netSales = listSales.Sum(item => item.amount)


                                   }).ToList();
            }

            //group period by years

            else 
            {
                netSaleByPeriod = (from sales in listSalesByDate
                                   group sales by sales.date.ToString("yyyy")
                                    into listSales
                                   select new NetSaleByPeriod
                                   {
                                       periodo = listSales.Key,
                                       netSales = listSales.Sum(item => item.amount)


                                   }).ToList();
            }


        }
    }
}

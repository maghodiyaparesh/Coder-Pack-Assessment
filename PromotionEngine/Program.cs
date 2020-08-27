﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public interface IPromotionEngine
    {
        int AValue { get; set; }
        int BValue { get; set; }
        int CValue { get; set; }
        int DValue { get; set; }

        int Promo1 { get; set; }
        int Promo2 { get; set; }
        int Promo3 { get; set; }

        int CalculateCartTotal(Dictionary<string, int> cartItems);
    }

    public class PromotionEngineClass
    {
        public int AValue { get; set; }
        public int BValue { get; set; }
        public int CValue { get; set; }
        public int DValue { get; set; }

        public int Promo1 { get; set; }
        public int Promo2 { get; set; }
        public int Promo3 { get; set; }

        public PromotionEngineClass()
        {
            AValue = 50;
            BValue = 30;
            CValue = 20;
            DValue = 15;

            Promo1 = 130;
            Promo2 = 45;
            Promo3 = 30;
        }

        public int CalculateCartTotal(Dictionary<string, int> cartItems)
        {
            int finalTotal = 0;
            int dItemRemain = 0;

            if (cartItems == null || !cartItems.Any())
                return 0;

            foreach(var items in cartItems)
            {
                if(items.Key.Equals("A"))
                {
                    finalTotal += ((items.Value / 3) * Promo1) + ((items.Value % 3) * AValue);
                }
                else if (items.Key.Equals("B"))
                {
                    finalTotal += ((items.Value / 2) * Promo2) + ((items.Value % 2) * BValue);
                }
                else if (items.Key.Equals("C") && cartItems.ContainsKey("D"))
                {
                    if (items.Value == cartItems["D"])
                    {
                        finalTotal += items.Value * Promo3;
                        dItemRemain = 0;
                    }
                    else if (items.Value > cartItems["D"])
                    {
                        finalTotal += (cartItems["D"] * Promo3) + ((items.Value - cartItems["D"]) * CValue);
                        dItemRemain = 0;
                    }
                    else
                    {
                        finalTotal += items.Value * Promo3;
                        dItemRemain = cartItems["D"] - items.Value;
                    }
                }
                else if (items.Key.Equals("C"))
                {
                    finalTotal += items.Value * CValue;
                }
                else if (items.Key.Equals("D"))
                {
                    finalTotal += dItemRemain * DValue;
                }
            }

            return finalTotal;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world");

            Console.ReadLine();
        }
    }
}

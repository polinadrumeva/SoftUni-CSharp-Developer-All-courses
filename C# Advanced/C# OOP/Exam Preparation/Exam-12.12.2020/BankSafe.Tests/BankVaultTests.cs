using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
            BankVault bankVault = new BankVault();
        }

        [Test]
        public void AddShouldThrowExceptionIfCellNotExist()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Polina", "9823928763");
            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.AddItem("F10", item);
            }, "Cell doesn't exists!");

        }

        [Test]
        public void AddShouldThrowExceptionIfCellIsFull()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Polina", "9823928763");
            Item item1 = new Item("Maria", "125661455");
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.AddItem("A1", item1);
            }, "Cell is already taken!");

        }

        [Test]
        public void AddShouldThrowExceptionIfIDAlreadyExist()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Polina", "9823928763");
            Item item1 = new Item("Maria", "9823928763");
            bankVault.AddItem("A1", item);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bankVault.AddItem("B1", item1);
            }, "Item is already in cell!");

        }

        [Test]
        public void AddShouldReturnCorrectData()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Polina", "9823928763");
           
            string actual = bankVault.AddItem("A1", item);
            string expected = $"Item:{item.ItemId} saved successfully!";
           
            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void RemoveShouldThrowExceptionIfCellNotExist()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Polina", "9823928763");
            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.RemoveItem("F10", item);
            }, "Cell doesn't exists!");

        }

        [Test]
        public void RemoveShouldThrowExceptionIfCellValueIsDifferent()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Polina", "9823928763");
            Item item1 = new Item("Maria", "455555364");
            bankVault.AddItem("A1", item);
            bankVault.AddItem("A2", item1);

            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.RemoveItem("A1", item1);
            }, $"Item in that cell doesn't exists!");

        }

        [Test]
        public void RemoveShouldReturnCorrectData()
        {
            BankVault bankVault = new BankVault();
            Item item = new Item("Polina", "9823928763");
            bankVault.AddItem("A1",item);

            string actual = bankVault.RemoveItem("A1", item);
            string expected = $"Remove item:{item.ItemId} successfully!";

            Assert.AreEqual(expected, actual);

        }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using SmartBear.TestLeft;
using SmartBear.TestLeft.TestObjects;


namespace TestLeftProject1
{
    [TestClass]
    public class TestLeftTest : UnitTestClassBase
    {
        #region Class initializers
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            UnitTestClassBase.InitializeClass(context);
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            UnitTestClassBase.FinalizeClass();
        }
        #endregion

        [TestMethod]
        public void HelloWorldTest()
        {
            Driver.Applications.Run("notepad.exe");

            // Get the top-level window of Notepad.
            // You can get object identification code from the TestLeft UI Spy panel:
            // From the main menu, select View -> Other Windows -> TestLeft UI Spy.
            ITopLevelWindow notepad = Driver.Find<IProcess>(new ProcessPattern()
            {
                ProcessName = "notepad"
            }).Find<ITopLevelWindow>(new WindowPattern()
            {
                WndClass = "Notepad"
            });

            notepad.Keys("Hello world!!"); // Simulate text input
        }


    }
}

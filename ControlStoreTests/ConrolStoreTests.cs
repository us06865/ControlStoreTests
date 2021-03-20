using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
using ControlStoreTestsCore;

namespace ControlStoreTests
{
    public class ConrolStoreTests
    {
        [TestFixture]
        public class ControlStoreTests
        {
            Core controlStoreCore;
            /// set up runs before each test OneTimeSetUp runs when class is instantiated
            [SetUp]
            public void Setup()
            {
                controlStoreCore = new Core();
                controlStoreCore.Initialize("file:///C:/Users/Casey/source/repos/ControlStore.html");

            }
            [TearDown]
            public void TearDown()
            {
                controlStoreCore.Terminate();
            }
            [Test]
            public void VerifyCheckBoxesSelection()
            {

                controlStoreCore.Click(controlStoreCore.CheckBoxesButton);
                Thread.Sleep(1000);
                controlStoreCore.Click("checkbox1");
                controlStoreCore.Click("checkbox3");
                controlStoreCore.Click(controlStoreCore.CheckBoxUpdateButton);
                string textFound=controlStoreCore.GetTextFromElement(controlStoreCore.CheckboxSelectedLabel);
                Assert.AreEqual("Checked 13", textFound, "CheckboxSelectedLabel does not display expected text.");
                Thread.Sleep(5000);
            }
            [Test]
            public void RadioButtonSelection()
            {
                controlStoreCore.Click(controlStoreCore.RadioButtonsButton);
                Thread.Sleep(1000);
                controlStoreCore.Click("radio1");
                controlStoreCore.Click(controlStoreCore.RadioButtonUpdate);
                controlStoreCore.Click("radio123Label");
                string textFound = controlStoreCore.GetTextFromElement(controlStoreCore.RadioSelectedLabel);
                Assert.AreEqual("Selected 1", textFound, "RadioSelectedLabel does not display expected text.");
                Thread.Sleep(5000);
            }
            [Test]
            public void DropdownsComboBoxSelection()
            {
                // IWebElement element = driver.FindElementByXPath("/html/ body / nav / ul / li[3] / button");
                controlStoreCore.Click(controlStoreCore.ComboBoxesButton);
                controlStoreCore.Click("combo1");
                //element = driver.FindElementByXPath("//*[@id=\"combo1\"]/option[3]");
                controlStoreCore.Click(controlStoreCore.ComboBoxOption3);
                // element = driver.FindElementByXPath("//*[@id=\"dropdownArticle\"]/section/ul/li[2]/button");
                controlStoreCore.Click(controlStoreCore.ComboBoxButtonUpdate);
                controlStoreCore.Click("comboLabel");
                string textFound = controlStoreCore.GetTextFromElement(controlStoreCore.ComboBoxLabel);
                Assert.AreEqual("Selected 2", textFound,"ComboBoxLabel does not display expected text.");
                Thread.Sleep(5000);

            }
        }
    }
}

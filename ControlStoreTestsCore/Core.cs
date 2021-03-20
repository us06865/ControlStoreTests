using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ControlStoreTestsCore
{
    public class Core
    {
        ChromeDriver driver;
        private Dictionary<string, By> Identifiers;

        #region Identifier Strings 
        #region Checkboxes 
        public string CheckBoxesButton = "html/body/nav/ul/li[1]/button";
        public string CheckBox1Id = "checkbox1";
        public string CheckBox2Id = "checkbox2";
        public string CheckBox3Id = "checkbox3";
        public string CheckBoxUpdateButton = "//*[@id=\"checkboxesArticle\"]/section/ul/li[4]/button";
        public string CheckboxSelectedLabel = "checkboxLabel";
        #endregion
        #region Radiobuttons
        public string RadioButtonsButton = "/html/body/nav/ul/li[2]/button";
        public string RadioButton1 = "radio1";
        public string RadioButtonUpdate = "//*[@id=\"radioButtonsArticle\"]/section/ul/li[4]/button";
        public string RadioSelectedLabel = "radio123Label";
        #endregion
        #region ComboBoxes
        public string ComboBoxesButton = "/html/body/nav/ul/li[3]/button";
        public string ComboBox1Id = "combo1";
        public string ComboBoxOption3 = "//*[@id=\"combo1\"]/option[3]";
        public string ComboBoxButtonUpdate="/html/body/page/article[3]/section/ul/li[2]/button";
        public string ComboBoxLabel = "comboLabel";

        #endregion
        #endregion

        public void Initialize(string startingUrl)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(startingUrl);
            Identifiers = new Dictionary<string, By>();
            Identifiers.Add(CheckBoxesButton, By.XPath(CheckBoxesButton));
            Identifiers.Add(CheckBox1Id, By.Id(CheckBox1Id));
            Identifiers.Add(CheckBox2Id, By.Id(CheckBox2Id));
            Identifiers.Add(CheckBox3Id, By.Id(CheckBox3Id));
            Identifiers.Add(CheckBoxUpdateButton,By.XPath(CheckBoxUpdateButton));
            Identifiers.Add(CheckboxSelectedLabel,By.Id(CheckboxSelectedLabel));
            Identifiers.Add(RadioButtonsButton, By.XPath(RadioButtonsButton));
            Identifiers.Add(RadioButton1, By.Id(RadioButton1));
            Identifiers.Add(RadioButtonUpdate, By.XPath(RadioButtonUpdate));
            Identifiers.Add(RadioSelectedLabel, By.Id(RadioSelectedLabel));
            Identifiers.Add(ComboBoxesButton, By.XPath(ComboBoxesButton));
            Identifiers.Add(ComboBox1Id, By.Id(ComboBox1Id));
            Identifiers.Add(ComboBoxOption3, By.XPath(ComboBoxOption3));
            Identifiers.Add(ComboBoxButtonUpdate, By.XPath(ComboBoxButtonUpdate));
            Identifiers.Add(ComboBoxLabel, By.Id(ComboBoxLabel));


        }

        public void Click(string locator)
        {
            By elementIdentifier = Identifiers[locator];
            try
            {
                driver.FindElement(elementIdentifier).Click();

            }
            catch (NotFoundException)
            {
                throw new Exception("Cound not find element using the ID" + locator
                    + "Review the identifier to see if it is correct");
            }
        }

        public string GetTextFromElement(string locator)
        {
            By elementIdentifier = Identifiers[locator];
            string textFound = string.Empty;
            textFound = driver.FindElement(elementIdentifier).Text;
            return textFound;

        }
        public void Terminate()
        {
            driver.Quit();
        }
    }
}

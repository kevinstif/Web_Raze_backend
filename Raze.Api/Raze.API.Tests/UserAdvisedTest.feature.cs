// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Raze.API.Tests
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class UserAdvisedServiceTestsFeature : object, Xunit.IClassFixture<UserAdvisedServiceTestsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "UserAdvisedTest.feature"
#line hidden
        
        public UserAdvisedServiceTestsFeature(UserAdvisedServiceTestsFeature.FixtureData fixtureData, Raze_API_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "", "UserAdvisedServiceTests", "As a Developer\r\nI want to add new UserAdvised through API\r\nSo that It can be avai" +
                    "lable for applicatios.", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
    #line hidden
#line 7
        testRunner.Given("the Endpoint https://localhost:5001/api/v1/useradviseds is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "Title",
                        "Description",
                        "Published"});
            table17.AddRow(new string[] {
                        "5",
                        "Casual",
                        "Casual Outfits",
                        "1"});
#line 8
        testRunner.And("Interest is already stored", ((string)(null)), table17, "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add UserAdvised")]
        [Xunit.TraitAttribute("FeatureTitle", "UserAdvisedServiceTests")]
        [Xunit.TraitAttribute("Description", "Add UserAdvised")]
        [Xunit.TraitAttribute("Category", "UserAdvised-adding")]
        public virtual void AddUserAdvised()
        {
            string[] tagsOfScenario = new string[] {
                    "UserAdvised-adding"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add UserAdvised", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 13
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                            "firstName",
                            "LastName",
                            "UserName",
                            "Password",
                            "age",
                            "mood",
                            "InterestId"});
                table18.AddRow(new string[] {
                            "George",
                            "Tyson",
                            "Demond",
                            "goku1234",
                            "25",
                            "3",
                            "5"});
#line 14
        testRunner.When("A UserAdvised Request is Sent", ((string)(null)), table18, "When ");
#line hidden
#line 17
        testRunner.Then("Response with status 200 is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "firstName",
                            "LastName",
                            "UserName",
                            "Password",
                            "age",
                            "Premiun",
                            "Profession",
                            "Mood",
                            "InterestId"});
                table19.AddRow(new string[] {
                            "10",
                            "George",
                            "Tyson",
                            "Demond",
                            "goku1234",
                            "25",
                            "false",
                            "Student",
                            "3",
                            "5"});
#line 18
        testRunner.And("A UserAdvised Resource is included in Response Body", ((string)(null)), table19, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Add UserAdvised with Invalid Interest")]
        [Xunit.TraitAttribute("FeatureTitle", "UserAdvisedServiceTests")]
        [Xunit.TraitAttribute("Description", "Add UserAdvised with Invalid Interest")]
        public virtual void AddUserAdvisedWithInvalidInterest()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add UserAdvised with Invalid Interest", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 22
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
    this.FeatureBackground();
#line hidden
                TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                            "firstName",
                            "LastName",
                            "UserName",
                            "Password",
                            "age",
                            "mood",
                            "InterestId"});
                table20.AddRow(new string[] {
                            "George",
                            "Tyson",
                            "Demond",
                            "goku1234",
                            "25",
                            "3",
                            "-50"});
#line 23
        testRunner.When("A UserAdvised Request is Sent", ((string)(null)), table20, "When ");
#line hidden
#line 26
        testRunner.Then("Response with status 400 is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 27
        testRunner.And("Message of \"Interst not found.\" is included in Response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                UserAdvisedServiceTestsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                UserAdvisedServiceTestsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion

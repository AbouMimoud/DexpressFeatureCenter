using System;
using DevExpress.ExpressApp.Demos;

namespace FeatureCenter.Module {
    public class Hints {
        public static void RegisterViewSpecificHints() {
            HintsRepository.Instance.RegisterHintForView("DashboardView1", DashboardViewSimpleHint);
            HintsRepository.Instance.RegisterHintForView("DashboardView2", DashboardViewVariantHint);
            HintsRepository.Instance.RegisterHintForView("DashboardView3", DashboardViewVariantHint);
            HintsRepository.Instance.RegisterHintForView("DashboardView4", DashboardViewAdvancedHint);
            HintsRepository.Instance.RegisterHintForView("PerformanceDashboard", PerformanceDashboardHint);
            HintsRepository.Instance.RegisterHintForView("SplashDemoDashboard", SplashDemoDashboardHint);
            HintsRepository.Instance.RegisterHintForView("Order_ListView_Default", GridListEditorsHint);
            HintsRepository.Instance.RegisterHintForView("Order_ListView_Chart_Countries", ChartModule_PieChartHint);
            HintsRepository.Instance.RegisterHintForView("Order_ListView_Chart_Employees", ChartModule_BarChartHint);
            HintsRepository.Instance.RegisterHintForView("Order_ListView_Chart_SalesByYears", ChartModule_AreaChartHint);
            HintsRepository.Instance.RegisterHintForView("Order_ListView_PivotGrid_SalesAnalysis", PivotModule_PivotGridHint);
            HintsRepository.Instance.RegisterHintForView("KpiDefinition_ListView", KPIDefinitionHint);
            HintsRepository.Instance.RegisterHintForView("KpiScorecard_ListView", KPIScorecardHint);
            HintsRepository.Instance.RegisterHintForView("ConcurrentModificationsDashboard", ConcurrentModificationsHint);
        }
        public const string DefaultXafSplashFormActionCaption = @"Click to test the default XAF
splash based on a custom form, 
which  displays  a  predefined 
and unchangeable static text";

        public const string DefaultXafWaitFormActionCaption =
 @"Click to test the default
XAF wait form powered by the
SplashScreenManager component
from the XtraEditors library";

        public const string CustomXtraSplashFormActionCaption =
 @"Click to test a custom
splash form powered by the
SplashScreenManager component
from the XtraEditors library";

        public const string CustomXtraSplashImageActionCaption =
 @"Click to test a splash with
a static image powered by the
SplashScreenManager component
from the XtraEditors library";

        public const string KPIDefinitionHint =
  @"To be able to view Key Performance Indicators, you first need to define them. The KPI module simplifies the process by providing a pre-configured Detail View designed specifically for this purpose. To see this View in action, click the New button on the main toolbar.";

        public const string KPIScorecardHint =
  @"You can easily organize Key Performance Indicators provided by the KPI module via Scorecards. They provide a quick overview of particular Key Performance Indicator results.";

        public const string GridListEditorsHint =
  @"By default, XAF applications use List Editors that provides the most common data representation in the form of a two-dimensional table. The GridListEditor is used in Windows Forms applications and the ASPxGridListEditor is used in ASP.NET Web applications.";

        public const string PivotModule_PivotGridHint =
  @"Pivot grid List Editors implemented in the Pivot Grid module can easily display financial information as a pivot table.
In Windows Forms applications, you can customize pivot table options via the List Editor's Property Editor. To do this, right-click the List Editor's region and select the 'Invoke Wizard' item.
You can also enable the accompanying chart that visualizes the data selected in the pivot table. In a Windows Forms application, right-click the List Editor's header region and select the 'Show Chart' item. In an ASP.NET Web application, use the 'Show Chart' Action available on the View toolbar.";

        public const string ChartModule_PieChartHint =
  @"Charting List Editors implemented in the Chart Module can easily display financial information as a pie chart.
In Windows Forms applications, you can customize chart options via the Chart Wizard. To do this, right-click the List Editor's region and select the 'Invoke Wizard' item.";

        public const string ChartModule_BarChartHint =
  @"Charting List Editors implemented in the Chart Module can easily display financial information a bar chart.
In Windows Forms applications, you can customize chart options via the Chart Wizard. To do this, right-click the List Editor's region and select the 'Invoke Wizard' item.";

        public const string ChartModule_AreaChartHint =
  @"Charting List Editors implemented in the Chart Module can easily display financial information an area chart.
In Windows Forms applications, you can customize chart options via the Chart Wizard. To do this, right-click the List Editor's region and select the 'Invoke Wizard' item.";

        public const string DashboardViewSimpleHint =
  @"Several Views can be displayed side-by-side on a single screen via a Dashboard View. Each displayed View is represented by a DashboardViewItem. A View displayed by an item can be specified via the View property of the Application Model's corresponding DashboardView node.";

        public const string DashboardViewAdvancedHint =
  @"Dashboard Views support a wide range of View Items. So, a Dashboard View can display not only Views but images, blocks of text and Action Containers.";

        public const string DashboardViewVariantHint =
  @"You may wish to provide several customized variants of the same Dashboard View, and allow an end-user to quickly switch to the desired View variant at runtime. When the varied Dashboard View is displayed, a user can select another variant either via the 'View' Action, or via the 'View Variants' navigation group's child items.";
        public const string SplashDemoDashboardHint =
  @"You can show a custom splash screen at application startup or any other moment by initializing the WinApplication.SplashScreen property with an object that implements the ISplash interface. You can either implement this interface from scratch or choose from several built-in implementations. You can also update your splash screen to notify users about current progress.";

        public const string CustomPropertyEditorsHint =
  @"Although built-in Property Editors cover most of the data management scenarios, you can implement custom Property Editors for those situations when the built-in editors do not suit your needs:
  - a DateTime type property is displayed via the Property Editor that lists the current month's dates only;
  - an Int32 type property is displayed via the Property Editor that uses a custom control;
  - a String type property is displayed via the Property Editor that lists cultures installed on the end-user's Windows operating system.";

        public const string CollectionPropertiesHint =
  @"Depending on the type of a collection property and the attributes applied, different Action sets are available in a UI.";

        public const string NumericPropertiesHint =
  @"Depending on the type of a numeric property (long, int, decimal and others), different formatting is used in a UI.";

        public const string ColorPropertiesDescription =
  @"You can select a color from a dropdown window with a color table or use the color picker to specify a custom color.";

        public const string BooleanPropertiesDescription =
  @"You can specify how a Boolean property will be displayed:
  - via a CheckEdit control, by default;
  - via a drop-down control where Boolean values are presented by custom text, if this text is specified in the Application Model;
  - via a drop-down control where Boolean values are presented by images and text, if these images and text are specified in the Application Model.";

        public const string CriteriaPropertiesHint =
  @"You can specify how a string property that stores filter criteria will be displayed:
  - via a special Filter Builder;
  - via an editor that allows you to specify a criterion manually, and via the Filter Builder located in the invoked popup window.
The Filter Builder provides you with the following capabilities:
  - the use of predefined XAF parameters in criteria;
  - the use of reference properties in criteria;
  - the use of complex path properties in criteria.";

        public const string DateTimePropertiesHint =
  @"TimeSpan and DateTime properties are displayed differently:
  - a DateTime editor;
  - a special editor for TimeSpan values.
Nullable DateTime properties are also supported.";

        public const string EnumPropertiesHint =
  @"You can specify how an enumeration property is displayed in List Views and Detal Views:
  - via a combobox with text entries;
  - via a combobox with text and image entries.";

        public const string ReferencePropertiesHint =
  @"You can specify how a reference property is displayed:
  - via a lookup control;
  - via editors that present properties of the referenced object individually;
  - via a Detail Property Editor that presents a Detail View for the referenced object;
  - via a button edit that allows to invoke a Detail View with the referenced object in a separate modal window (usually used for aggregated objects).";

        public const string StringPropertiesHint =
  @"Depending on the attributes applied to a string property and the accompanying settings specified in the Application Model, a string property is displayed differently:
  - string properties with a fixed length (e.g. 100 or 15 characters) are displayed via a text editor;  
  - large string properties (see UnlimitedSizeStringProperty) are displayed via a memo editor. By default, such properties aren't displayed in List Views;
  - string properties declared with the StringCompressionConverter attribute (see CompressedUnlimitedStringProperty) are stored in the database in a compressed form;
  - if predefined values are specified in the Application Model, string properties are displayed via a combobox editor";

        public const string StringInSpecialFormatPropertiesHint =
  @"String properties that store non-plain text data are displayed via special Property Editors:
  - string properties can be displayed via an editor that supports HTML (Hyper Text Markup Language) formatting;";

        public const string CustomFormattedPropertiesHint =
  @"You can provide a custom formatting via the DisplayFormat and EditMask properties in the Application Model. By setting the EditMaskType property to RegEx you can also use regular expressions as the EditMask value";
        public const string RichTextPropertiesHint =
  @"The Rich Text Editor control is a powerful word-processing tool that allows you to create, load, modify, print, save and convert rich text documents in different formats. You can use RichTextEditor to represent a byte array or string property.";
        public const string WinSpreadsheetPropertiesHint =
  @"The WinForms Spreadsheet emulates the Microsoft® Excel® look and feel and allows you to create, load, edit, save and print spreadsheet documents.";

        public const string StructPropertiesHint =
  @"Structure properties are fully supported via built-in Property Editors:
  - a root class has the 'Details' property of the 'DetailDescription' type that represents a structure with the Id and Name properties;
  - public fields and properties are expanded into a set of editors;
  - all properties are read-only (for value types, this is 'by design').";

        public const string FileAttachmentPropertiesHint =
  @"File properties are fully supported out of the box via the File Attachments module:
  - the 'File' property of the built-in FileData type is displayed via a special FileDataPropertyEditor.
  - the 'Files' collection of associated files is accompanied by additional Actions: 'Create from file', 'Save To' and 'Open'.";

        public const string ImagePropertiesHint =
  @"An image persisted as a byte array property can be displayed:
  - via the PictureEdit control in Detail Views, by default (in List Views they are not displayed, by default);
  - via a PictureEdit control in List Views, if the ImageEditorMode.PictureEdit mode is set for the property.
  - via a drop-down control in List Views and Detail Views, if the ImageEditorMode.DropDownPictureEdit mode is set for the property.";

        public const string CustomFieldsDescription =
 @"You can extend your existing business models with custom properties defined via the Model Editor at design time or runtime. 
Here, you can see examples of regular custom fields, storing their values in the database, as well as non-persistent calculated fields that compute their values based on other data expressed via any valid criteria expression.";


        public const string RuleRequiredFieldHint =
  @"The RuleRequiredField attribute demands that a particular property has a value. Here, this rule is applied to the RequiredDateTimeProperty and RequiredStringProperty properties. 
To check this rule, save the current object.";

        public const string RuleCriteriaHint =
  @"The RuleCriteria attribute demands that the current object satisfies a specified criteria. Here, this rule is applied to the RuleCriteriaObject class to demand that the following criteria are satisfied:
- A complex criteria where properties are compared with static values.
- A criteria where a property is compared with a read-only parameter.
- A criteria where two properties are compared with each other.
To check this rule, save the current object.";

        public const string RuleRangeHint =
  @"Th RuleRange attribute demands that a particular IComparable property's value falls within the specified range. Here, this rule is applied to the following properties:
 - ""FromOneToFive"" must be set to a value that is greater than 1 and less than 5, inclusive;
 - ""During2008"" must be set to a date that falls within the year 2008.
 - ""LastSevenDays"" must be set to a date that falls within the last seven days. Here, built-in XPO functions (AddDays and LocalDateTimeToday) are demonstrated.
 - ""Collection"": the sum of all the collection elements' SumBetween0And50 property values must be greater than 0 and less than 50, inclusive;
 - ""Collection"": the collection must contain at least one element with the AtLeastOneValueWithinFirstWeekOf2009 property set to a date within the first week of the year 2009.
To check this rule, save the current object.";

        public const string RuleValueComparisonHint =
  @"The RuleValueComparison attribute demands that a particular IComparable property satisfies a specific expression. Here, this rule is illustrated using the following six operators:
 > (the GreaterThanZero and Collection properties);
 = (the Equals100 and Collection properties);
 >= (the NotLessThanOne property);
 != (the NotEquals1000 property);
 < (the BeforeFebruary2008 property);
 <= (the NotMoreThan10 property).
The BeforeToday property demonstrates use of the built-in XPO LocalDateTimeToday function as an operand value.
To check this rule, save the current object.";

        public const string RuleStringComparisonHint =
  @"The RuleStringComparison attribute demands that a particular string property satisfies a specific expression. Here, this rule is illustrated using the following five operators:
 - StartsWith (the StartsWithAbc property);
 - EndsWith (the EndsWithXyz property);
 - Contains (the ContainsXXX property);
 - Equals (the EqualsValid property);
 - NotEquals (the DoesNotEqualInvalid property).
To check this rule, save the current object.";

        public const string RuleRegularExpressionHint =
  @"The RuleRegularExpression attribute demands that a particular string property matches a specific pattern. Here, this rule is illustrated using a pattern for Email addresses.
To check this rule, save the current object.";

        public const string RuleFromBoolPropertyHint =
  @"The RuleFromBoolProperty attribute demands that a particular object satisfy a specific complex criteria. The criteria is introduced by a Boolean property, which is usually non-persistent. Here, the following properties apply this rule:
 - The IsComplexExpressionValid property returns true if the MustBeTrue property is set to true, the length of the LengthMoreThan10 property value is more than 10 and the ContainsValid property value contains ""Valid"". To highlight properties with incorrect data, their names are passed as the UsedProperties parameter in the RuleFromBoolProperty attribute.
 - The IsFullStringValid property returns true if the FullString property value represents a concatenation of the LeftPart, MiddlePart and RightPart property values.
To check this rule, save the current object.";

        public const string RuleObjectExistsHint =
  @"The RuleObjectExists attribute demands that a particular type object satisfying a specific criteria exist in the database. Here, this rule is checked when the current object represents a student (see the Position property). For this purpose, the rule's TargetCriteria property is specified.
This rule demands that there must be teachers who teach the subject assigned for the student.
To check this rule, save the current object.";

        public const string RuleUniqueValueHint =
  @"The RuleUniqueValue attribute demands that there must not be any objects that have a particular property set to the same value as the current object's property. Here, this rule is applied to the UniqueValue and Collection properties.
To check this rule, save the current object.";

        public const string RuleIsReferencedHint =
  @"The RuleIsReferenced attribute demands that an object should be referenced in objects of a specific type. Here, this rule is inverted. It's valid when there are no objects that have a reference to the current object. 
This rule is checked when deleting an object.";

        public const string RuleCombinationOfPropertiesIsUniqueHint =
  @"The RuleCombinationOfPropertiesIsUnique attribute demands that a combination of the specified properties is unique. Here, this rule is used to check a combination of the Description and Type properties.
To check this rule, save the current object.";

        public const string CodeRuleHint =
  @"You can implement a custom rule via the CodeRule attribute. Code rules are usually designed for the following purposes:
 - to check an object using a highly tailored algorithm;
 - to apply a rule to an object that is implemented in a referenced assembly, without using the Model Editor.
Here, a custom rule is implemented for the CodeRuleObject type objects. It uses the following algorithm to check objects:
 - if PersonName is not specified, a validation error is raised;
 - if PersonName is specified, Sex is set to Male, but TitleOfCourtesy is not set to ""Mr"", a validation error is raised;
 - if PersonName is specified, Sex is set to Female, but TitleOfCourtesy is set to ""Mr"", a validation error is raised;
 - in other cases, the rule is valid.
For each case a rule is broken, a message template is specified to be written in the Validation Error window.
This rule is checked when saving an object.";

        public const string CustomRuleHint =
  @"You can implement a custom rule attribute by inheriting from the RulePropertyValue<TPropertyValue> class. Here, such a rule is created to check the length of the specified string property. The rule is applied using a specially designed custom rule attribute in code or in the Application Model. The following properties are checked:
 - MoreThan5Symbols must consist of more than five symbols;
 - NotMoreThanTenSymbols value length must not exceed 10;
This rule is checked when saving an object.";

        public const string ValidationMessageTemplatesHint =
  @"You can specify custom validation message templates that are displayed in the Validation Error window:
- RuleCriteria checks the Date and Price properties of the referenced DateAndPrice object, and demonstrates how to use read-only parameters and formatted current values of complex path properties (e.g. DateAndPrice.Date.DayOfWeek) in the message;
- RuleStringComparison checks the ContainsAbc and GreaterThanZero properties, and demonstrates how to use reserved parameters and rule-specific property values in the message;
- RuleFromBoolProperty checks the IsFullStringValid property, and demonstrates how to use the current values of the validated object's properties in the message.
All these rules are checked when saving an object.";

        public const string SimpleValidationSettingsHint =
  @"Simple rule settings can be easily specified:
 - RuleRange, applied to the NotFromZeroToTen property. This rule is inverted. It's broken when the property's value is outside the (0,10) interval. For this purpose, InvertResult is set to true. 
 - RuleStringComparison, applied to the DoesNotContainABC property. This rule is inverted to be broken when the property value doesn't contain ""ABC"". For this purpose, InvertResult, IgnoreCase and SkipNullOrEmptyValues are set to true.
 - RuleRequiredField, applied to the RequiredField property. This rule is checked if only the following complex criteria is satisfied by the object: ""DoesNotContainABC like '%XYZ%' AND NotFromZeroToTen > 5"". This criteria is set for TargetCriteria.
All these rules are checked when saving an object.";

        public const string ComplexValidationSettingsHint =
  @"Complex rule settings can be easily specified:
 - RuleObjectExists, applied to the ComplexValidationSettingsObject class. This rule is inverted. It's broken when objects with the same FirstName and LastName property values exist. So, a custom text is set for MessageTemplateMustExist to be written in the Validation Error winodw. To list the found objects, the FoundObjectMessageFormat is specified and a custom separator is set for FoundObjectMessagesSeparator.
 - RuleIsReferenced, applied the ComplexValidationSettingsObject class. This rule is inverted to be broken when there are objects that reference the current object. So, a custom text is set for MessageTemplateMustExist to be written in the Validation Error window. To list the found objects, the FoundObjectMessageFormat is specified and a custom separator is set for FoundObjectMessagesSeparator.
The RuleObjectExists rule is checked, when saving an object; the RuleIsReferenced is checked, when deleting an object.";

        public const string MiscellaneousValidationFeaturesHint =
  @"The Validation system provides various useful capabilities:
- A rule can be checked in a custom context. Here, executing the ""Validate In Custom Context"" Action invokes validation of the rules that are designed to be checked in the custom ""IsAllowedToExecuteAction"" context.
- In a validation error message, the name of the validated property is taken from the Application Model, instead of using the actual property name. This allows you to write user-friendly validation error messages. In addition, localized messages may contain a localized name of the validated property.
- The header of the validation messages can be localized.
To check the predefined rules, do the following:
- Use the ""Validate"" Action to validate an object in all available contexts.
- Use the ""Save"" Action to validate an object in the ""Save"" context.
- Use the ""Validate In Custom Context"" Action to validate an object in the custom ""IsAllowedToExecuteAction"" context.";

        public const string SoftValidationHint =
  @"By default, validation rules are strict, i.e. a user should correct validation errors in order to proceed saving (or executing other actions in the current validation context). However, you can implement soft validation rules that can be ignored by uses. Here, the following rules are demonstrated:
- A validation error dialog that cannot be ignored is displayed when saving an object with the IsError property set to true;
- A validation warning dialog that can be ignored is displayed when saving an object with the IsWarning property set to true;
- The 'info' icon is displayed near the property editor when saving an object with the IsInformation property set to true. The icon’s tooltip displays the validation information.
To check these rules, save the current object.";

        public const string ObjectWithInplaceReportsHint =
  @"You can preview \ print inplace reports for the selected object(s) via the 'Show in Report' Action. This Action's items represent the inplace reports that are designed for the current List View's data type.";

        public const string SkinDemoObjectHint =
  @"Various themes and skins inspired by popular software products as well as unique skins designed by DevExpress are available out of the box.";

        public const string LocalizationHint =
  @"You can easily localize your application so that a UI, control-specific messages and captions, property names and enumeration values use the same language. 
The default language is used when the PreferredLanguage attribute of the Application Model's Application node is set to ""(Default Language)"". Values in the default language correspond to the ones that are used in the Model Editor when the Language editor in the XAF Model Editor toolbox is set to ""(Default Language)"". 
The German language is used when the PreferredLanguage attribute of the Application Model's Application node is set to ""de"". Values in the German language correspond to the ones that are used in the Model Editor when the Language editor in the XAF Model Editor toolbox is set to ""de"".
The default formatting options (see the DecimalProperty and DateTime properties in the current View) correspond to the ones that are set in the current user's operating system or passed by the Internet browser.
The German formatting options (see the DecimalProperty and DateTime properties in the current View) correspond to the ones that are set in the German format culture. 
Note that the CurrencyProperty's values always use the $ currency symbol, because the application's module handles the Application.CustomizeFormattingCulture event to fix this formatting option.";

        public const string SimpleActionHint =
  @"A Simple Action is used to execute custom code when an end-user clicks the associated button. Herem, several Actions are added to the toolbars, to show how to set various properties and get the required behavior.";

        public const string ActionsInDetailViewHint =
  @"Actions can be displayed on a Detail View's layout via the ActionContainerViewItem. The View Item's ActionContainer property specifies the category of the displayed Actions.";

        public const string ParametrizedActionHint =
  @"A Parametrized Action is used to execute custom code when an end-user enters a value into the associated editor. Here, several Actions are added to the toolbars, to show how to set properties and get the required behavior.";

        public const string PopupWindowShowActionHint =
  @"A Popup Window Show Action is used to invoke a popup Window with a specified View and execute custom code when an end-user clicks the accepting or cancelling button.
Here, several Actions are added to the toolbars, to show how to set properties and get the required behavior. Any kind of View can be shown in the invoked popup window.";

        public const string SingleChoiceActionHint =
  @"A Single Choice Action is used to execute custom code when an end-user selects an item from the associated list control.
Here, several Actions are added to the toolbars, to show how to set properties and get the required behavior.";

        public const string FilterByTextRootObjectHint =
  @"Try typing words and word combination via the FilterByText Action, available out of the box, to filter the presented object collection. By default, the following properties are included in search:
- any persistent property of the current object;
- any persistent property of the aggregated object;
- the default property of the referenced object.";

        public const string FilterByTextOptionsObjectHint =
  @"You can easily exclude individual properties from the search performed by the FilterByText Action, by applying the SearchMemberOptions attribute and passing SearchMemberMode.Exclude as a parameter. Alternatively, you can specify the properties that will take part in the search. For this purpose, apply the SearchClassOptions attribute with the SearchMemberMode.Exclude parameter value to the class, and the MemberSearchOptions attribute with the SearchMemberMode.Include parameter value to the required properties.
The object represented by this View uses the SearchClassOptions attribute with the SearchMemberMode.Exclude parameter value. The IncludedProperty uses the SearchMemberOptions attribute with the SearchMemberMode.Include parameter value. So, when executing the FilterByText Action, only the IncludedProperty will take part in the search.";

        public const string IntegerKeyObjectHint =
  @"Persistend object can have integer key properties, whose values are generated automatically.";

        public const string GuidKeyObjectHint =
  @"Persistend object can have Guid key properties, whose values are generated automatically.";

        public const string StringKeyObjectHint =
  @"Persistend object can have string key properties, whose values are generated automatically.";

        public const string EventDemoObjectHint =
  @"The System module allows you to print scheduling information and exposes several Actions:

- Page Setup. Invokes the Page Setup window, where an end-user can set up page printing options.
- Print Preview. Shows how the scheduler will be printed. An end-user can make changes in the prepared page; for instance, add color, margins, header, footer and so on. For this purpose, there are numerous options in the Preview window.
- Print. Invokes the Print dialog, where an end-user can set up printing options, and print the prepared page.

Here, when saving options in the Page Setup window and the ""Header and Footer"" options in the Preview window, you can specify whether they will be then applied to the current View or all the Views in the application. To do this, before saving, set the Printing Settings Storage. In custom applications, to set this storage, use the Printing Controller's PrintingSettingsStorage property.";

        public const string TreeListDemoObjectHint =
  @"The System Module module allows you to print data which has a tree-like structure and exposes several Actions:

- Page Setup. Invokes the Page Setup window, where an end-user can set up page printing options.
- Print Preview. Shows how the treelist will be printed. An end-user can make changes in the prepared page; for instance, add color, margins, header, footer and so on. For this purpose, there are numerous options in the Preview window.
- Print. Invokes the Print dialog, where an end-user can set up printing options, and print the prepared page.

Here, when saving options in the Page Setup window and the ""Header and Footer"" options in the Preview window, you can specify whether they will be then applied to the current View or all the Views in the application. To do this, before saving, set the Printing Settings Storage. In custom applications, to set this storage, use the Printing Controller's PrintingSettingsStorage property.";

        public const string LayoutDemoObjectHint =
  @"The System Module module allows you to print Detail Views and exposes several Actions:

- Page Setup. Invokes the Page Setup window, where an end-user can set up page printing options.
- Print Preview. Shows how the Detail View will be printed. An end-user can make changes in the prepared page; for instance, add color, margins, header, footer and so on. For this purpose, there are numerous options in the Preview window.
- Print. Invokes the Print dialog, where an end-user can set up printing options, and print the prepared page.

Here, when saving options in the Page Setup window and the ""Header and Footer"" options in the Preview window, you can specify whether they will be then applied to the current View or all the Views in the application. To do this, before saving, set the Printing Settings Storage. In custom applications, to set this storage, use the Printing Controller's PrintingSettingsStorage property.";

        public const string GridDemoObjectHint =
  @"The System Module module allows you to print List Views and exposes several Actions:

- Page Setup. Invokes the Page Setup window, where an end-user can set up page printing options.
- Print Preview. Shows how the grid will be printed. An end-user can make changes in the prepared page; for instance, add color, margins, header, footer and so on. For this purpose, there are numerous options in the Preview window.
- Print. Invokes the Print dialog, where an end-user can set up printing options, and print the prepared page.

Here, when saving options specified in the Page Setup window and the ""Header and Footer"" options specified in the Preview window, you can specify whether they will be then applied to the current View or all the Views in the application. To do this, before saving, set the Printing Settings Storage. In custom applications, to set this storage, use the Printing Controller's PrintingSettingsStorage property.";

        public const string ImageSourceBrowserStandardImagesHint =
  @"The standard image library is represented by the DevExpress.ExpressApp.Images assembly and contains a lot of images you can use.";

        public const string ImageSourceBrowserCustomImagesHint =
  @"You can implement custom image libraries. This library is represented by the 'CustomImages' project from the demo's solution.";

        public const string NavigationObjectHint =
  @"The navigation system is represented in a UI by the navigation control, which lists all the available Views and provides means to activate the required View.";

        public const string NavigationStyleNavBarHint =
  @"The current navigation style is NavBar, where a navbar control is used as the navigation control. The first-level child nodes of the NavigationItems node represent the navbar's groups. These groups cannot be used to navigate to Views even if the ViewID attributes are set. The groups only serve as containers for other child nodes.";

        public const string NavigationStyleTreeListHint =
  @"The current navigation style is TreeList, where a treelist control is used as the navigation control. The displayed tree is identical to the navigation structure.";

        public const string DefaultNavigationChildItemsDisplayStyleListHint =
  @"The current navigation group style is List, where a navbar group is displayed as a treelist. This treelist's structure is identical to the structure of the NavagationItems node's child node represented by the navbar group.";

        public const string DefaultNavigationChildItemsDisplayStyleIconsHint =
  @"The current navigation group style is Large Icons, where a navbar group is displayed as a set of icons specified by the ImageName attributes of the corresponding NavigationItem nodes. Only the second-level child nodes of the NavigationItems node are displayed.";

        public const string GridListEditorDemoObjectHint =
  @"ASPxGridListEditor and GridListEditor can easily work with large amounts of data in Server Mode. It is enabled for this View via the Application Model's DataAccessMode attribute of the Application | Views | ListView node.
To see Server Mode in action, configure the Windows Forms and ASP.NET FeatureCenter applications to use the same database. Start the Windows Forms FeatureCenter application and execute the 'Create Demo Objects' Action. This will create 20000 demo objects in the database. After that, you can observe the performance while working with these objects in both the Windows Forms and ASP.NET FeatureCenter applications.";

        public const String DataAccessModeDemoObjectHint =
            @"In List Views, you can easily work with large amount of data using the Server, Data View or Instant Feedback mode instead of the default Client mode. The mode can be selected via the Application Model's DataAccessMode property of the Application | Views | ListView node.

- Client mode: the entire record set required for the current List View is loaded into memory. All the data processing takes place on the client side.
- DataView mode: a lightweight read-only list of data records is retrieved without loading complete persistent objects.
- Server mode: data is requested from a data store in small portions that should currently be displayed. All data-aware operations are performed on the data server side.
- Instant Feedback mode: in WinForms applications, use this mode to load data asynchronously. This mode is similar to the Server one, but the grid control doesn't freeze and continues responding to a user's actions while data is being retrieved by the data source in a background thread. This mode is not available in ASP.NET applications.

Configure the WinForms and ASP.NET FeatureCenter applications to use the same database. Start the WindForms FeatureCenter application and execute the 'Create Demo Objects' Action (which is unavailable in the ASP.NET demo). This will create 20000 demo objects in the database. After that, you can observe performance while working with these objects in various modes in both WinForms and ASP.NET applications. To switch the mode, use the 'Select DataAccessMode' Action.";

        public const string GridListEditorFilterDemoObjectHint =
  @"The Filter Action, available in your applications out of the box, is intended to apply one of the predefined filters to the current List View. Try selecting different values to filter the presented object collection.";

        public const string GridListEditorAutoFilterDemoObjectHint =
  @"The Automatic Filter Row allows data to be filtered on the fly, by typing text within the row. When text is typed within the row, a filter condition is automatically created based upon the value entered, and applied to the focused data column. 
Try entering different text in the filter row and observe the results in the List Editor.";

        public const string GridListEditorNewItemRowDemoObjectHint =
  @"The ASPxGridListEditor and GridListEditor support the new item row and in-place editing features.
The new item row is represented by an empty row which is used to enter new records, without invoking a Detail View. 
The in-place editing enables you to edit cell values in a specific manner and format, making it easy for end-users to input data.";

        public const string GridListEditorBatchEditDemoObjectHint =
@"The ASPxGridListEditor and GridListEditor support the new item row and in-place editing features.
The new item row is represented by an empty row which is used to enter new records, without invoking a Detail View. 
The in-place editing enables you to edit cell values in a specific manner and format, making it easy for end-users to input data.";

        public const string SchedulerListEditorDemoObjectHint =
  @"The SchedulerListEditor can easily work with large amounts of data, and doesn't require Server Mode to be enabled.
Configure the Windows Forms and ASP.NET FeatureCenter applications to use the same database.
Start the Windows Forms FeatureCenter application and execute the 'Create Demo Objects' Action. This will create 20000 demo objects in the database. 
After that, you can observe the performance while working with these objects in both the Windows Forms and ASP.NET FeatureCenter applications.";

        public const string SchedulerListEditorFilterDemoObjectHint =
  @"The Filter Action, available in your applications out of the box, is intended to apply one of the predefined filters to the current List View. Try selecting different values to filter the presented object collection.";

        public const string SchedulerListEditorFilterByTextDemoObjectHint =
  @"The FilterByText Action, available in your applications out of the box, allows you to easily filter List Views. Try typing words and word combinations to filter the presented object collection. The following properties are included in search by default:
- any persistent property of the current object;
- any persistent property of the aggregated object;
- the default property of the referenced object.";

        public const string TreeListEditorDemoObjectHint =
  @"The ASPxTreeListEditor and TreeListEditor can easily work with large amounts of data in Server Mode, and don't require Server Mode to be enabled.
Configure the Windows Forms and ASP.NET FeatureCenter applications to use the same database.
Start the Windows Forms FeatureCenter application and execute the 'Create Demo Objects' Action. This will create 20000 demo objects in the database. 
After that, you can observe the performance while working with these objects in both the Windows Forms and ASP.NET FeatureCenter applications.
	";

        public const string TreeListEditorNodeImagesDemoObjectHint =
  @"The ASPxTreeListEditor and TreeListEditor can display images for nodes. To support node images, a class implementing the ITreeNode interface can support an additional ITreeNodeImageProvider interface.";

        public const string TreeListEditorFilterDemoObjectHint =
  @"The Filter Action, available in your applications out of the box, is intended to apply one of the predefined filters to the current List View. Try selecting different values to filter the presented object collection.";

        public const string TreeListEditorFilterByTextObjectHint =
  @"The FilterByText Action, available in your applications out of the box, allows you to easily filter List Views. Try typing words and word combinations to filter the presented object collection. The following properties are included in search by default:
- any persistent property of the current object;
- any persistent property of the aggregated object;
- the default property of the referenced object.";

        public const string TreeListEditorFilterByTextOptionsObjectHint =
  @"You can easily exclude individual properties from the search performed by the FilterByText Action by applying the SearchMemberOptions attribute and passing SearchMemberMode.Exclude as a parameter. Alternately, you can specify the properties that will take part in the search. For this purpose, apply the SearchClassOptions attribute with the SearchMemberMode.Exclude parameter value to the class, and the MemberSearchOptions attribute with the SearchMemberMode.Include parameter value to the required properties.
The object represented by this View uses the SearchClassOptions attribute with the SearchMemberMode.Exclude parameter value. The IncludedProperty uses the SearchMemberOptions attribute with the SearchMemberMode.Include parameter value. So, when executing the FilterByText Action, only the included properties will take part in the search.";
        public const string CustomListEditorObjectHint =
  @"Although built-in List Editors cover most of the data management scenarios, you can implement custom List Editors for those situations when the built-in editors do not suit your needs.
Here, a custom List Editor displays DVD covers. This List Editor is designed to display objects, implementing a custom IPictureItem interface as a list of images, one for each object.";

        public const string AuditSettings =
  @"The Audit module can easily be configured to record audit information only for certain properties. The Name and AuditedProperty properties are audited. The NonAuditedProperty is excluded from audit.";

        public const string WebCustomizeControl =
  @"You can customize control that visualizes the current Action using ActionBase.CustomizeControl event. This event allows to customize controls for: 
     - ShowNavigationItemAction
     - ASPxGridView Inline Actions
     - ActionContainerHolder Actions
    ";
        public const string WinCustomizeControl =
  @"You can customize control that visualizes the current Action using ActionBase.CustomizeControl event. This event allows to customize controls for:
     - ShowNavigationItemAction
     - BarManager Actions
     - LayoutManager Actions
    ";

        public const string AuditObjectAuditingModes =
  @"The Audit module supports several object auditing modes:
Full - All object changes are fully audited. This mode is the default one. 
Lightweight - Only object creation, deletion and modification are audited. Doesn't audit names and values of changed properties. 
CreationOnly - Only object creation is audited. Intended for data importing purposes. 
To see these modes in action, select audit mode via the 'Choose Audit Mode' Action and make some changes to the demo properties. After that, click 'Save' and look at the created audit log.";

        public const string AuditCollectionProperties =
  @"The Audit module can easily be used to record audit information for collection properties. Here, changes made to aggregated and non-aggregated collection properties are registered and saved to the AuditTrail collection.";

        public const string AuditSimpleProperties =
  @"The Audit module can easily be used to record audit information for properties of a business class. Here, changes made to properties of various types are registered and saved to the AuditTrail collection.";

        public const string AuditPartiallyDisabled =
  @"You can partially disable the Audit module, to quickly load a large number of objects, with acceptable performance, while still getting certain audit information.
After executing the ""Create Demo Objects"" Action, 20000 objects are created. While the objects are being created, property change audit is disabled.
After the objects have been created, audit is fully re-enabled.";

        public const string AuditFullyEnabled =
  @"Here, you can assess performance of the Audit module when creating a large number of objects or invoking Detail Views containing a lot of audit information.
After executing the ""Create Demo Objects"" Action, 500 objects are created. After the objects have been created, they are modified in a random way.";

        //        public const string WelcomeText =
        //@"This demo has been designed to help you quickly get acquainted with the eXpressAppFramework and start using it effectively. 
        //If you are new to the eXpressApp Framework, you can get a glimpse of various features offered by XAF. Each individual demo shows off some particular XAF feature and comes with a description of that functionality.
        //If you are a seasoned XAF developer, this demo can prove valuable to you too. You can refer to this demo's source code to see how some specific behavior can be implemented.
        //
        //To navigate through the individual demos, use the tree view on the left.";

        public const string LayoutDemoItemTemplatesHint =
  @"You can use custom layout item and group templates. For this purpose, LayoutManager exposes the LayoutItemTemplate, LayoutGroupTemplate and TabbedGroupTemplate properties.

Invoke the Detail View, and you will be presented with three Property Editors, which allow you to activate custom Templates:
- The custom layout item template includes the question mark, which displays hints;
- The custom layout group template uses the ASPxRoundPanel control to display layout groups;
- The custom tabbed group template uses the ASPxPageControl to display tabbed layout groups. The control is configured, so that the tabs are displayed on its left side.";

        public const string LayoutDemoDefaultFocusedItemHint =
  @"You can specify the Property Editor to be focused when a Detail View is invoked. For this purpose, set the DefaultItem attribute of the Application Model's Application | Views | DetailView node to the required value.";

        public const string ViewVariantsObjectHint =
  @"You may wish to provide several customized variants of the same View, and allow an end-user to choose the desired View variant at runtime. View variants are available both in List and Detail Views:
When the varied List View is displayed, you can select a variant either via the 'View' Action, or via the 'View Variants' navigation group's child items. 
When the varied Detail View is displayed, you can select a variant via the 'View' Action.";

        public const string PerformanceWarningText =
  @"Currently, the Feature Center isn't connected to a database server. An XML file is used instead of a real database.
It is recommended that you provide a valid SQL Server connection string via the App.config/Web.config file.
You can run the demonstration without connecting the Feature Center to a database server. However, in this instance,
performance is likely to be seriously degraded, and the results will not reflect actual XAF performance.";

        public const string ConditionalAppearance_FormatAppearanceObjectHint =
  @"The ConditionalAppearance module allows you to declare conditional appearance rules to customize the font style and color of the text displayed by Property Editors:
- the style of the text displayed by the TargetFormattingProperty Property Editor is based on the FontStyle property value;
- the color of the text displayed by the TargetFormattingProperty Property Editor is based on the Priority property value;
- the background color of TargetFormattingProperty Property Editor caption is red when the Severity property is set to 'Severe';
- the background color of RelatedObject Property Editor caption is yellow when the Priority property is set to 'Normal'.";

        public const string ConditionalAppearance_LayoutItemAppearanceObjectHint =
  @"The ConditionalAppearance module allows you to declare conditional appearance rules to customize the font style and color of the text displayed by Layout Items:
- the style of the TargetFormattingProperty Property Editor caption is based on the FontStyle property value;
- the color of the TargetFormattingProperty Property Editor caption is based on the Priority property value;
- the background color of TargetFormattingProperty Property Editor caption is red when the Severity property is set to 'Severe'.";

        public const string ConditionalAppearance_TreeListFormattedObjectHint =
  @"The ConditionalAppearance module allows you to declare conditional appearance rules to customize the font style and color of the text displayed by Property Editors:
- the style of the text displayed by the Name Property Editor is based on the FontStyle property value;
- the color of the text displayed by the Name Property Editor is based on the Priority property value;
- the background color of the Name Property Editor is red when the Severity property is set to 'Severe'.";

        public const string ConditionalAppearance_ActionControlObjectHint =
  @"The ConditionalAppearance module allows you to declare conditional appearance rules to disable/enable Actions. Here, the Delete Action is disabled when the DisableDeleteAction property value is true.";

        public const string ConditionalAppearance_DisableEnableEditorsObjectDCHint =
  @"The ConditionalAppearance module can work with Domain Components out of the box:
- SimpleProperty is disabled in any View when the corresponding flag is set;
- LookupProperty is disabled in any View when the corresponding flag is set;
- AggregatedProperty itself and its editors when disabled when the corresponding flags are set;
- Collection properties are disabled in any View when the corresponding flags are set;";

        public const string ConditionalAppearance_DisableEnableEditorsObjectHint =
  @"The ConditionalAppearance module allows you to declare conditional appearance rules to disable/enable Property Editors. Here, the following Property Editors are demonstrated:
- Simple Property Editor is disabled in any View when the corresponding flag is set;
- Lookup Property Editor is disabled in any View when the corresponding flag is set;
- Aggregated Property itself and its editors are disabled wheh the corresponding flags are set;
- Collection Propert Editors are disabled in any View when the corresponding flags are set;
- PropertyDisabledByStaticMethod Property Editor is always disabled in any View;
- PropertyDisabledByInstanceMethod Property Editor is disabled when it's set to 'You cannot edit me' string.";

        public const string ConditionalAppearance_HideShowEditorsObjectHint =
  @"The ConditionalAppearance module allows you to declare conditional appearance rules to hide/show different Property Editors and Layout Items and Groups. Here, they are hidden when the corresponding flags are set.";

        public const string ConditionalAppearance_SelectAllPropertiesObjectHint =
  @"Usually, when declaring a conditional appearance rule via the ConditionalApperance module, you should list all the properties you are going to customize. It is quite difficult if your class has a lot of properties.
Using the * wildcard you can select all the class properties for customization. If a property is listed together with the '*' wildcard, then it will be excluded from the customization.
Here, a rule is declared to disable the Name and Description properties when the DisableProperties flag is set. The DisableProperties property is excluded from the customization and it is always available.";

        public const string ConditionalAppearance_SuperpositionOfRulesbjectHint =
  @"When using the ConditionalAppearance module, sometimes it is necessary to declare several rules that will affect the same properties. 
For example, one rule may disable an editor under some circumstances, and another rule may enable the same editor, but under different circumstances.
However, there may be situations when rules will concur with each other. In this instance, a rule that applies customization always wins in competition with a rule that cancels customization for the same editor.
Here, two rules are declared to disable all the properties of the demo object except for the property that is chosen in the command drop down list (All Properties Disabled Except).
 - According to the first rule, when Property1 is chosen in the command drop-down list, it should not be possible to edit any properties except for Property1.
 - According to the second rule, when Property2 is chosen in the command drop-down list, it should not be possible to edit any properties except for Property2.
As you see, here one of the rules always disables editors according to its criteria, and another, concurring one, always enables editors because their criteria are exclusive.";

        public const string DCPersistentPropertiesHint =
  @"Domain components can declare various properties. Here you can see the following properties:
- Value type properties - Name and Birthday;
- A property referencing a persistent object - Organization;
- A property referencing an entity instance - Spouse;
- A collection property - Phones.
 Click the 'C# Code' tab to see the corresponding source code.";
        public const string DCAssociationsHint =
  @"Domain components can participate in one-to-many and many-to-many relationships. Here you can see the following:
- One-to-many relationship - Company-Owners;
- One-to-many relationship with aggregation - Company-Departments;
- Many-to-many relationship - Companies-Addresses.
Click the 'C# Code' tab to see the corresponding source code.";
        public const string DCMultipleInheritanceHint =
  @"A domain component can aggregate several domain components. Here you can see that, for instance, IOfficeManager aggregates IManager. At the same time IProductManager aggregates two domain components - IManager and IEvangelist. Click the 'C# Code' tab to see the corresponding source code.";
        public const string DCDomainLogicForPropertiesHint =
  @"Domain components can have associated specific classes called domain logic. These classes' methods provide implementation for members declared in a domain component.
Here, a domain logic for properties is implemented:
-	The Price property value is saved before it is changed;
-	PreviousPrice property is set to the saved value and this information is saved to Log, after the Price property has changed;
-	The Delta property is calculated in its getter;
-	The Reviews collection is filtered by the product name specified by the Name property.
Click the 'C# Code' tab to see the corresponding source code. To see a complete list of possible domain logic methods refer to the product documentation.";
        public const string DCDomainLogicForMethodsHint =
  @"Domain components can have associated specific classes called domain logic. These classes' methods provide implementation for members declared in a domain component.
Here, a domain logic for methods declared in a domain component is implemented:
-	The Postpone method, which is declared as an Action, modifies the DueDate property. This method is called when the Postpone Action is executed;
-	The CreateReport creates a report with the Text property set to the value passed as a parameter;
-	The AfterConstruction method initializes properties. To specify the Report property, it calls the CreateReport method with “new task” passed as a parameter.
Click the 'C# Code' tab to see the corresponding source code. To see a complete list of possible domain logic methods refer to the product documentation.";
        public const string DCDomainLogicInheritanceHint =
  @"A domain component can override an inherited domain logic. For this purpose, simply provide a new domain logic implementation. Here IClient_Logic overrides the Get_DisplayName logic method inherited from IPerson. Click the 'C# Code' tab to see the corresponding source code.";

        public const string ConcurrentModificationsHint =
  @"In XAF applications, one user can edit a record while another user is editing the same record. As long as the changes being made do not affect the same field, XAF can resolve the situation and merge simultaneous changes made by different users. In this demo, the same Person object is loaded in two Views that emulate two applications sharing the same database. To see how XAF handles concurrency, modify several property values and save changes in both Views.";
        public const string EventNotificationsHint = @"This example demonstrates how the Notifications module works together with the Scheduler module and the DevExpress.Persistent.BaseImpl.Event class. Initially, a notification window containing two reminders is invoked (one for an event in the past, the other for the event that starts in five minutes). The third event starts in 10 minutes, so the initial notification window does not include it. You can add more events (note that reminders are refreshed every minute).";
        public const string TaskNotificationsHint = @"This example demonstrates how the Notifications module works with the custom ‘Task’ business class without the use of the Scheduler module. Initially, a notification window containing two reminders is invoked (one for a task in the past, the other for the task that starts in five minutes). The third task starts in 10 minutes, so the initial notification window does not include it. You can add more tasks (note that reminders are refreshed every minute).";
        public const string PerformanceDashboardHint = @"This example demonstrates the Delayed Loading in Detail Views. When this feature is enabled, the Detail View is opened faster, but the actual data is displayed later, after it has been loaded from the data source. To compare the Delayed Loading mode with the default behavior, open two Detail Views from the both lists above. To enable delayed loading in your app, use the WinApplication.DelayedDetailViewDataLoading property.";
        public const string NonPersistentWithCollectionHint = @"This example demonstrates how to show a collection property in a non-persistent object's Detail View.";
        public const string NonPersistentWithPersistentPropertytHint = @"This example demonstrates how to show a non-persistent object's Detail View from navigation. Additionally, it shows how to declare a property of a persistent type in a non-persistent class and display it in the user interface.";
        public const string NonPersistentObjectsListHint = @"This example demonstrates how to show a non-persistent object's List View from navigation.";

        public const string MessagesHint = @"Sometimes you want to notify end-users about successful execution of a command (e.g., saving changes) or perform additional actions after a user clicks or closes such a notification, like in Microsoft Outlook. Displaying text notifications (e.g. confirmation messages, warnings, errors) has been made simpler for desktop and Web XAF applications. Use our new Application.ShowViewStrategy.ShowMessage method that runs equally well across WinForms and ASP.NET platforms.";
    }

    public class Captions {
        public const string Welcome = "Welcome";

        public const string AuditGroup = "Audit";
        public const string Audit_Settings = "Audit Settings";
        public const string Audit_ObjectAuditingModes = "Object Auditing Modes";
        public const string Audit_CollectionPropertiesAudit = "Collection Properties Audit";
        public const string Audit_SimplePropertiesAudit = "Simple Properties Audit";
        public const string Audit_PartiallyAuditedBatchCreation = "Import Data With Partial Audit";
        public const string Audit_FullyAuditedBatchCreation = "Audit Performance";

        public const string ConditionalAppearanceGroup = "Conditional Appearance";
        public const string ConditionalAppearance_Formatting = "Object Properties Formatting";
        public const string ConditionalAppearance_Formatting_LayoutItem = "Layout Item Properties Formatting";
        public const string ConditionalAppearance_Formatting_TreeList = "TreeList Editors Support";
        public const string ConditionalAppearance_ActionControl = "Disabling/Enabling Actions";
        public const string ConditionalAppearance_DisablingEnablingEditors = "Disabling/Enabling Editors";
        public const string ConditionalAppearance_HidingShowingEditors = "Hiding/Showing Editors";
        public const string ConditionalAppearance_UsingWildcard = "Using the * Wildcard";
        public const string ConditionalAppearance_SuperpositionOfRules = "Superposition of Rules";

        public const string FilteringGroup = "Filtering";
        public const string Filtering_FilterByText = "Filter by Text";
        public const string Filtering_FilterByTextOptions = "Filter by Text Options";

        public const string KeyPropertyGroup = "Key Property";
        public const string KeyProperty_GuidKey = "Guid Key";
        public const string KeyProperty_IntegerKey = "Integer Key";
        public const string KeyProperty_StringKey = "String Key";

        public const string ListEditors_CustomListEditor = "Custom List Editor";

        public const string PrintingGroup = "Printing";
        public const string Printing_Scheduler = "Scheduler";
        public const string Printing_Grid = "Grid";
        public const string Printing_Layout = "Layout";
        public const string Printing_Layout_NestedObjectWithIntegerProperty = "Nested Object with an Integer Property";
        public const string Printing_Layout_NestedObjectWithBooleanProperty = "Nested Object with a Boolean Property";
        public const string Printing_TreeList = "TreeList";

        public const string PropertyEditorsGroup = "Property Editors";
        public const string PropertyEditors_BooleanProperties = "Boolean Properties";
        public const string PropertyEditors_ColorProperties = "Color Properties";
        public const string PropertyEditors_CollectionProperties = "Collection Properties";
        public const string PropertyEditors_CollectionProperties_BindingListProperty = "BindingList<> Property";
        public const string PropertyEditors_CollectionProperties_ReadOnlyBindingListProperty = "ReadOnly BindingList<> Property";
        public const string PropertyEditors_CustomPropertyEditors = "Custom Property Editors";
        public const string PropertyEditors_ImageProperties = "Image Properties";
        public const string PropertyEditors_StringInSpecialFormatProperties = "String In Special Format Properties";
        public const string CustomFields = "Custom Fields";

        public const string ReportsGroup = "Reports";
        public const string Reports_ObjectWithInplaceReports = "Object With Inplace Reports";

        public const string ValidationGroup = "Validation";
        public const string Validation_CustomRule = "Check Value with Custom Rule";
        public const string Validation_MiscellaneousValidationFeatures = "Miscellaneous Validation Features";
        public const string Validation_MiscellaneousValidationFeatures_PropertyWithDisplayNameAttribute = "Property Name adjusted in code";
        public const string Validation_RuleCombinationOfPropertiesIsUnique = "Combination of Values Must be Unique";
        public const string Validation_RuleCriteria = "Conform to Criteria";
        public const string Validation_RuleFromBoolProperty = "Test with Boolean Property";
        public const string Validation_RuleIsReferenced = "Check Object is not Referenced";
        public const string Validation_RuleObjectExists = "Test Object Exists";
        public const string Validation_RuleRange = "Must be in Range";
        public const string Validation_RuleRegularExpression = "Test Value with Regular Expression";
        public const string Validation_RuleRequiredField = "Required Field";
        public const string Validation_RuleStringComparison = "Test Value as String";
        public const string Validation_RuleUniqueValue = "Value Must be Unique";
        public const string Validation_RuleValueComparison = "Compare Value to Another";
        public const string Validation_SimpleValidationSettings = "Simple Validation Settings";
        public const string Validation_TailoredRule = "Check Value with Tailored Algorithm";
        public const string Validation_ValidationMessageTemplates = "Validation Message Templates";
        public const string Validation_ErrorandWarning = "Soft Validation";
        public const string Validation_InplaceValidation = "Inplace Validation";

        public const string Validation_ComplexValidationSettings = "Complex Validation Settings";

        public const string LayoutGroup = "Layout";

        public const string ViewVariantsGroup = "View Variants";

        public const string DCGroup = "Domain Components";

        public const string MapsGroup = "Maps";
    }
}

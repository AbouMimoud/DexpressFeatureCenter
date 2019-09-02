using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FeatureCenter.Module.Reports {
    public class ContactReportLayout {
        static readonly string reportLayout = @"<?xml version=""1.0"" encoding=""utf-8""?>
<XtraReportsLayoutSerializer SerializerVersion=""19.1.0.0"" Ref=""1"" ControlType=""DevExpress.XtraReports.UI.XtraReport, DevExpress.XtraReports.v19.1, Version=19.1.0.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4"" Name=""ContactReport"" DisplayName=""Contacts Report (editable)"" PageWidth=""850"" PageHeight=""1100"" Version=""19.1"" DataSource=""#Ref-0"">
  <Extensions>
    <Item1 Ref=""2"" Key=""DataSerializationExtension"" Value=""XtraReport"" />
    <Item2 Ref=""3"" Key=""DataEditorExtension"" Value=""XtraReport"" />
    <Item3 Ref=""4"" Key=""ParameterEditorExtension"" Value=""XtraReport"" />
  </Extensions>
  <Bands>
    <Item1 Ref=""5"" ControlType=""DetailBand"" Name=""Detail"" HeightF=""134.25"" TextAlignment=""TopLeft"" Padding=""0,0,0,0,100"">
      <Controls>
        <Item1 Ref=""6"" ControlType=""XRLabel"" Name=""xrLabel9"" Text=""xrLabel9"" SizeF=""470.0001,17.99999"" LocationFloat=""174, 81.00001"" Padding=""2,2,0,0,100"">
          <ExpressionBindings>
            <Item1 Ref=""7"" Expression=""[Position.Title]"" PropertyName=""Text"" EventName=""BeforePrint"" />
          </ExpressionBindings>
        </Item1>
        <Item2 Ref=""8"" ControlType=""XRLabel"" Name=""xrLabel1"" Text=""First Name"" SizeF=""162,18"" LocationFloat=""6, 9"" StyleName=""FieldCaption"" Padding=""2,2,0,0,100"" />
        <Item3 Ref=""9"" ControlType=""XRLabel"" Name=""xrLabel2"" Text=""Last Name"" SizeF=""162,18"" LocationFloat=""6, 33"" StyleName=""FieldCaption"" Padding=""2,2,0,0,100"" />
        <Item4 Ref=""10"" ControlType=""XRLabel"" Name=""xrLabel3"" Text=""Email"" SizeF=""162,18"" LocationFloat=""6, 57"" StyleName=""FieldCaption"" Padding=""2,2,0,0,100"" />
        <Item5 Ref=""11"" ControlType=""XRLabel"" Name=""xrLabel4"" Text=""Position"" SizeF=""162,18"" LocationFloat=""6, 81"" StyleName=""FieldCaption"" Padding=""2,2,0,0,100"" />
        <Item6 Ref=""12"" ControlType=""XRLabel"" Name=""xrLabel5"" Text=""Birthday"" SizeF=""162,18"" LocationFloat=""6, 105"" StyleName=""FieldCaption"" Padding=""2,2,0,0,100"" />
        <Item7 Ref=""13"" ControlType=""XRLabel"" Name=""xrLabel6"" Text=""xrLabel6"" SizeF=""470,18"" LocationFloat=""174, 9"" StyleName=""DataField"" Padding=""2,2,0,0,100"">
          <ExpressionBindings>
            <Item1 Ref=""14"" Expression=""[FirstName]"" PropertyName=""Text"" EventName=""BeforePrint"" />
          </ExpressionBindings>
        </Item7>
        <Item8 Ref=""15"" ControlType=""XRLabel"" Name=""xrLabel7"" Text=""xrLabel7"" SizeF=""470,18"" LocationFloat=""174, 33"" StyleName=""DataField"" Padding=""2,2,0,0,100"">
          <ExpressionBindings>
            <Item1 Ref=""16"" Expression=""[LastName]"" PropertyName=""Text"" EventName=""BeforePrint"" />
          </ExpressionBindings>
        </Item8>
        <Item9 Ref=""17"" ControlType=""XRLabel"" Name=""xrLabel8"" Text=""xrLabel8"" SizeF=""470,18"" LocationFloat=""174, 57"" StyleName=""DataField"" Padding=""2,2,0,0,100"">
          <ExpressionBindings>
            <Item1 Ref=""18"" Expression=""[Email]"" PropertyName=""Text"" EventName=""BeforePrint"" />
          </ExpressionBindings>
        </Item9>
        <Item10 Ref=""19"" ControlType=""XRLabel"" Name=""xrLabel10"" Text=""xrLabel10"" SizeF=""470,18"" LocationFloat=""174, 105"" StyleName=""DataField"" Padding=""2,2,0,0,100"">
          <ExpressionBindings>
            <Item1 Ref=""20"" Expression=""[Birthday]"" PropertyName=""Text"" EventName=""BeforePrint"" />
          </ExpressionBindings>
        </Item10>
        <Item11 Ref=""21"" ControlType=""XRLine"" Name=""xrLine1"" SizeF=""638,2"" LocationFloat=""6, 3"" />
      </Controls>
    </Item1>
    <Item2 Ref=""22"" ControlType=""PageFooterBand"" Name=""pageFooterBand1"" HeightF=""29"">
      <Controls>
        <Item1 Ref=""23"" ControlType=""XRPageInfo"" Name=""xrPageInfo1"" PageInfo=""DateTime"" SizeF=""313,23"" LocationFloat=""6, 6"" StyleName=""PageInfo"" Padding=""2,2,0,0,100"" />
        <Item2 Ref=""24"" ControlType=""XRPageInfo"" Name=""xrPageInfo2"" TextFormatString=""Page {0} of {1}"" TextAlignment=""TopRight"" SizeF=""313,23"" LocationFloat=""331, 6"" StyleName=""PageInfo"" Padding=""2,2,0,0,100"" />
      </Controls>
    </Item2>
    <Item3 Ref=""25"" ControlType=""ReportHeaderBand"" Name=""reportHeaderBand1"" HeightF=""51"">
      <Controls>
        <Item1 Ref=""26"" ControlType=""XRLabel"" Name=""xrLabel11"" Text=""Contacts"" SizeF=""638,33"" LocationFloat=""6, 6"" StyleName=""Title"" Padding=""2,2,0,0,100"" />
      </Controls>
    </Item3>
    <Item4 Ref=""27"" ControlType=""TopMarginBand"" Name=""topMarginBand1"" />
    <Item5 Ref=""28"" ControlType=""BottomMarginBand"" Name=""bottomMarginBand1"" />
  </Bands>
  <StyleSheet>
    <Item1 Ref=""29"" Name=""Title"" BorderStyle=""Inset"" Font=""Times New Roman, 20pt, style=Bold"" ForeColor=""Maroon"" BackColor=""Transparent"" BorderColor=""Black"" Sides=""None"" StringFormat=""Near;Near;0;None;Character;Default"" BorderWidthSerializable=""1"" />
    <Item2 Ref=""30"" Name=""FieldCaption"" BorderStyle=""Inset"" Font=""Arial, 10pt, style=Bold"" ForeColor=""Maroon"" BackColor=""Transparent"" BorderColor=""Black"" Sides=""None"" StringFormat=""Near;Near;0;None;Character;Default"" BorderWidthSerializable=""1"" />
    <Item3 Ref=""31"" Name=""PageInfo"" BorderStyle=""Inset"" Font=""Times New Roman, 10pt, style=Bold"" ForeColor=""Black"" BackColor=""Transparent"" BorderColor=""Black"" Sides=""None"" StringFormat=""Near;Near;0;None;Character;Default"" BorderWidthSerializable=""1"" />
    <Item4 Ref=""32"" Name=""DataField"" BorderStyle=""Inset"" Padding=""2,2,0,0,100"" Font=""Times New Roman, 10pt"" ForeColor=""Black"" BackColor=""Transparent"" BorderColor=""Black"" Sides=""None"" StringFormat=""Near;Near;0;None;Character;Default"" BorderWidthSerializable=""1"" />
  </StyleSheet>
  <ComponentStorage>
    <Item1 Ref=""0"" Name=""collectionDataSource1"" ObjectTypeName=""FeatureCenter.Module.Reports.ContactForReport"" ObjectType=""DevExpress.Persistent.Base.ReportsV2.CollectionDataSource,DevExpress.Persistent.Base.v19.1"" TopReturnedRecords=""0"">
      <Sorting Ref=""33"" />
    </Item1>
  </ComponentStorage>
</XtraReportsLayoutSerializer>
";
        public static byte[] ReportLayout {
            get {
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(ConvertVersion(reportLayout));
                return byteArray;
            }
        }
        private static string ConvertVersion(string reportLayout) {
            string result = reportLayout;
            result = result.Replace("VSuffix", AssemblyInfo.VSuffix);
            result = result.Replace("dllVersion", AssemblyInfo.Version);
            result = result.Replace("dllPublicKeyToken", AssemblyInfo.PublicKeyToken);
            result = result.Replace("VersionShort", AssemblyInfo.VersionShort);
            return result;
        }
    }
}

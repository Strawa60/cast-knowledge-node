<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksSearchForm.aspx.cs" Inherits="KsiegarniaCDA.GUI.WebForms.BooksSearchForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Księgarnia CDA</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		<div id="divHeader" style="width:100%; height:50px; border: 1px dashed green; text-align:center; font-size:large; padding-top:20px">
			<asp:Label ID="lblPageTitle" runat="server" Text="Wyszukiwanie książek" />
		</div>
		<div style="width:100%; border: 1px dashed red;">
			<fieldset style="padding:10px 0px">
			<legend>Kryteria wyszukiwania</legend>
			<span style="margin: 0px 10px;">
				<asp:Label ID="lblGatunek" runat="server" Text="Gatunek" Width="90px" />
				<asp:DropDownList ID="drpGatunki" runat="server" Width="100px" DataTextField="Text" DataValueField="Value" />
			</span>
			<span style="margin: 0px 10px;">
				<asp:Label ID="lblAutor" runat="server" Text="Autor" Width="90px" />
				<asp:DropDownList ID="drpAutorzy" runat="server" Width="100px" DataTextField="Text" DataValueField="Value" />
			</span>
			<span style="margin: 0px 10px;">
				<asp:Label ID="lblTytul" runat="server" Text="Tytul" Width="90px" />
				<asp:TextBox ID="txtTytul" runat="server" Width="120px" />
			</span>
			<br />
			<br />
			<span style="margin: 0px 10px;">
				<asp:Label ID="lblRokWydania" runat="server" Text="Rok wydania" Width="90px" />
				<asp:TextBox ID="txtRokWydania" runat="server" Width="90px" />
			</span>
			<span style="margin: 0px 10px;">
				<asp:Label ID="lblWydawnictwo" runat="server" Text="Wydawnictwo" Width="90px" />
				<asp:TextBox ID="txtWydawnictwo" runat="server" Width="90px" />
			</span>
			<span style="margin: 0px 10px;">
				<asp:Label ID="lblOpis" runat="server" Text="Opis" Width="90px" />
				<asp:TextBox ID="txtOpis" runat="server" Width="120px" />
			</span>
			</fieldset>
		</div>
		<div style="text-align:center; padding:10px">
			<asp:Button ID="btnSearch" runat="server" Text="Szukaj" OnClick="btnSearch_Click" />
		</div>
		<div style="width:100%; border: 1px dashed blue;">
			<fieldset style="padding:10px 0px">
			<legend>Wyniki wyszukiwania</legend>
				<asp:GridView ID="grdResults" runat="server" AutoGenerateColumns="false" DataKeyNames="IdKsiazki">
				<Columns>
					<asp:BoundField HeaderText="Tytuł" ItemStyle-Width="120px" DataField="Tytul" />
					<asp:BoundField HeaderText="Autor" ItemStyle-Width="120px" DataField="Autor" />
					<asp:BoundField HeaderText="Gatunek" ItemStyle-Width="120px" DataField="Gatunek" />
					<asp:BoundField HeaderText="Rok wydania" ItemStyle-Width="100px" DataField="RokWydania" />
				</Columns>
				</asp:GridView>
			</fieldset>
		</div>
    </div>
    </form>
</body>
</html>

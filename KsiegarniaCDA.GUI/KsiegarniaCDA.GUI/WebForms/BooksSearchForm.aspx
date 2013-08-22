<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksSearchForm.aspx.cs" Inherits="KsiegarniaCDA.GUI.WebForms.BooksSearchForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<fieldset style="padding:10px 0px">
    <legend>Kryteria wyszukiwania</legend>
    <span style="margin: 0px 10px;">
        <asp:Label ID="lblGatunek" runat="server" Text="Gatunek" Width="90px" />
        <asp:DropDownList ID="drpGatunki" runat="server" Width="100px" />
    </span>
    <span style="margin: 0px 10px;">
        <asp:Label ID="lblAutor" runat="server" Text="Autor" Width="90px" />
        <asp:DropDownList ID="drpAutorzy" runat="server" Width="100px" />
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
</fieldset>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

<asp:Button ID="btnSearch" runat="server" Text="Szukaj" onclick="btnSearch_Click" />


    <br />


<asp:GridView ID="grdResults" runat="server" AutoGenerateColumns="false" 
        Height="50px" Width="1008px">
    <Columns>
        <asp:BoundField HeaderText="Tytuł" ItemStyle-Width="120px" />
        <asp:BoundField HeaderText="Autor" ItemStyle-Width="120px" />
        <asp:BoundField HeaderText="Gatunek" ItemStyle-Width="120px" />
        <asp:BoundField HeaderText="Rok wydania" ItemStyle-Width="100px" />
    </Columns>
</asp:GridView>
</body>
</html>

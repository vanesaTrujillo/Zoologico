﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PKoala.aspx.cs" Inherits="ZoologicoVJ.PKoala" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="background-image: url('img/fondo.png'); text-align: center; height: 1008px; width: 1082px;">
    <div style="font-family: 'Berlin Sans FB'; font-size: 57px; color: #008000; height: 59px; clip: rect(auto, 10px, auto, 10px);">
    
        KOALA<br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
        <asp:ImageButton ID="ImageButton1" runat="server" Height="229px" ImageAlign="TextTop" ImageUrl="~/img/Koala.jpg" style="margin-top: 17px" Width="282px" />
        <br />
        <br />
        <br />
        <br />
        <br />

        
<TABLE Border="1" width="50%">
<TR>
<TH colspan ="2" style="color: green; font-size: 12pt">Koala</TH>

</TR>
<TR>
<TD style="color: green; font-size: 12pt" >Numero de patas</TD>
<TD>####</TD>
</TR>
<TR>
<TD style="color: green; font-size: 12pt">Edad</TD>
<TD>###</TD>
</TR>
<TR>
<TD style="color: green; font-size: 12pt">Pais de origen</TD>
<TD>####</TD>
</TR>
<TR>
<TD style="color: green; font-size: 12pt">Especie</TD>
<TD>####</TD>
</TR>
    <TR>
<TD style="color: green; font-size: 12pt">Sobre especie</TD>
<TD>####</TD>
</TR>
    <TR>
<TD style="color: green; font-size: 12pt">Habitos alimenticios</TD>
<TD>####</TD>
</TR>

</TABLE>
        <br />
        <asp:Button ID="Button1" runat="server" BackColor="#CCCC00" BorderColor="#99CC00" Height="32px" PostBackUrl="~/ActualizarRegisMami.aspx" Text="Actualizar Registro" Width="168px" />
    </form>
</body>
</html>

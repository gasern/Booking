<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" ContentType="text/xml" %>
<data>
    <% foreach (var myevent in (IEnumerable) Model) { %>
        <event id="<%=myevent.id%>">
            <start_date><![CDATA[<%=    String.Format("{0:MM/dd/yyyy HH:mm}",myevent.start_date) %>]]></start_date>
            <end_date><![CDATA[<%=      String.Format("{0:MM/dd/yyyy HH:mm}",myevent.end_date) %>]]></end_date>
            <text><![CDATA[<%=          myevent.text%>]]></text>
        </event>
    <% } %>
</data>
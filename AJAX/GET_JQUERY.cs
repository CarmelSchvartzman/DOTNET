<!DOCTYPE html>
<html>
<head>
    <script src="Scripts/jquery-1.10.2.min.js"></script>    
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />    
    <meta charset="utf-8" />
    <script>
        $(document).ready(function () {
             
            $.get('Default.aspx', {id:7}, function (res, status, xhr) {          //<<<<<<<<<<<<       
                console.log(res);
                $('#Id').html('<mark>' + res.Key + '</mark>');
                $('#Name').html('<pre>' + res.Value + '</pre>');     
            }, 'json');
            
        });
    </script>
</head>
<body>
    <div class="container">
        <div class="jumbotron">
            <div class="row-content">
                <div class="col-md-6">
                    Id =
                </div>
                <div id="Id" class="col-md-6">
                </div>
            </div>
            <div class="row-content">
                <div class="col-md-6">
                    Name =
                </div>
                <div id="Name" class="col-md-6">
                </div>
            </div>
        </div>
    </div>
</body>
</html>


using System.Web.Script.Serialization;
  protected void Page_Load(object sender, EventArgs e)
        { 
            Trace.Warn("Before ");
            JavaScriptSerializer jss = new JavaScriptSerializer();

            int id = 0;
            Int32.TryParse(Convert.ToString(Request["id"]), out id);

            string s = jss.Serialize(new { Key = id, Value = "Bender" });     //<<<<<<<<<<<<
            Response.Write(s);                                   //<<<<<<<<<<<<
                    
            
            Trace.Warn("After ");
        }

var dir = new DirectoryInfo(@"E:\Code\2\TheOtherUs\TheOtherRoles");
var file = File.Open(dir.FullName + @"\TheOtherRoles.cs", FileMode.Open, FileAccess.Read);

var reader = new StreamReader(file);

while (reader.ReadLine() is { } line)
{
    if ()
    {
        
    }
}
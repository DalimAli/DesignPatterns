using Strategy.DesignPattern;

ICompression strategy = new ZipCompression();
//Pass ZipCompression Strategy as an argument to the CompressionContext constructor
CompressionContext ctx = new CompressionContext(strategy);
ctx.CreateArchive("DotNetDesignPattern");
//Changing the Strategy using SetStrategy Method
ctx.SetStrategy(new RarCompression());
ctx.CreateArchive("DotNetDesignPattern");
Console.Read();
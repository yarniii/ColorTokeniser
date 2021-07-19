
namespace CSharp
{ 
    using System;
    
    public sealed class  HTMLTokenVisitor:ITokenVisitor
    {
       
        public   void Visit(ILineStartToken line)
        {
            Console.Write("<span class=\"line_number\">");
            Console.Write("{0,3}",line.Number());
            Console.Write("</span>");
        }
      
                
       
        public   void Visit(IIdentifierToken token)
        {
            SpannedFilteredWrite("identifier", token);
        }
        public   void Visit(ICommentToken t)
        {
           SpannedFilteredWrite("comment", t);
        }
        public   void Visit(IKeywordToken t)
        {
            SpannedFilteredWrite("keyword",t);
        }
        public   void Visit(IWhiteSpaceToken t)
        {
            Console.Write(t.ToString());
        }
        public    void Visit(IOtherToken t)
        {
            FilteredWrite(t);
        }
        public void Visit(ILineEndToken t) { }
        private  void FilteredWrite(IToken token)
        {
            String src=token.ToString();
            for (int i = 0; i != src.Length; i++)
            {
                String dst;
                switch (src[i])
                {
                    case '<':
                        dst="&lt;";break;
                    case '>':
                        dst="&gt;";break;
                    case '&':
                        dst="&amp;";break;
                    default:
                        dst=new string(src[i],1);break;
                }
                Console.Write(dst);
            }
        }
        private void SpannedFilteredWrite(string spanName, IToken token)
        {
            Console.Write("<span class=\"{0}\">",spanName);
            FilteredWrite(token);
            Console.Write("</span");
        }
        public void Visit(IDirectiveToken token)
{
SpannedFilteredWrite("directive", token);
} 
      
        // Add methods here
    }
}

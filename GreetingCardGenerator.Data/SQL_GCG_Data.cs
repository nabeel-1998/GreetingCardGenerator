using Microsoft.EntityFrameworkCore;
using GreetingCardGenerator.Core;
using System.Collections.Generic;
using System.Linq;

namespace GreetingCardGenerator.Data
{
    public class SQL_GCG_Data : IAppData
    {
        private readonly GreetingCardGeneratorDbContext db;

        public SQL_GCG_Data(GreetingCardGeneratorDbContext db)
        {
            this.db = db;
        }

        public Sales AddNewPurchase(Sales sales)
        {
            db.Sales.Add(sales);
            Commit();
            return sales;
        }

        int Commit()
        {
            return db.SaveChanges();
        }

        public void AddNewTemplate(Template template)
        {
            db.Templates.Add(template);
            Commit();
            
        }

        public Admin AdminLogin(Admin admin)
        {
            var Entity = db.Admins.Where(
                x => x.EMAIL == admin.EMAIL && x.PASSWORD_HASH == admin.PASSWORD_HASH)
                .FirstOrDefault();
            return Entity;
        }

        public void DeleteAGreeting(int greetingId)
        {
            var entity = db.Greetings.Where(x => x.GREETING_ID == greetingId).FirstOrDefault();
            db.Greetings.Remove(entity);
            Commit();
        }

        public void DeleteATemplate(int templateId)
        {
            var entity = db.Templates.Where(x => x.TEMPLATE_ID == templateId).FirstOrDefault();
            db.Templates.Remove(entity);
            Commit();
        }

        public Member Login(Member member)
        {
            var User = db.Members.
                Where(x => x.EMAIL == member.EMAIL && x.PASSWORD_HASH == member.PASSWORD_HASH).
                FirstOrDefault();
            return User;
        }

        public void SaveGreetingDraft(Greeting_Draft draft)
        {
            db.GreetingDrafts.Add(draft);
            Commit();
        }

        public void SaveTemplateDraft(Template_Draft draft)
        {
            db.Template_Drafts.Add(draft);
            Commit();
        }

        public Member Signup(Member member)
        {
            db.Members.Add(member);
            if(Commit()==1)
            {
                return member;
            }
            return null;
        }

        public void UpdateAGreeting(Greetings greeting)
        {
            var Entity = db.Greetings.Attach(greeting);
            Entity.State = EntityState.Modified;
            Commit();
        }

        public List<Greetings> ViewAllGreetings()
        {
            var EntityList = db.Greetings.ToList();
            return EntityList;
        }

        public List<Member> ViewAllMembers()
        {
            var EntityList = db.Members.ToList();
            return EntityList;
        }

        public List<Sales> ViewAllSalesByUser(int userId)
        {
            var SalesList = db.Sales.Where(x => x.CUSTOMER_ID == userId).ToList();
            return SalesList;
        }

        public List<Template> ViewAllTemplates()
        {
            var EntityList = db.Templates.ToList();
            return EntityList;
        }

        public List<Greeting_Draft> ViewGreetingDraftsByUser(int userId)
        {
            var EntityList = db.GreetingDrafts.Where(x => x.CUSTOMER_ID == userId).ToList();
            return EntityList;
        }

        public List<Template_Draft> ViewTemplateDraftByUser(int userId)
        {
            var EntityList = db.Template_Drafts.Where(x => x.CUSTOMER_ID == userId).ToList();
            return EntityList;
        }

        public List<string> GetGreetingByLetter(char a)
        {
            List<string> glist = new List<string>();
            var list = db.Greetings.Where(x => x.LETTER == a.ToString()).ToList();
            foreach(var item in list)
            {
                glist.Add(item.GREETING);
            }
            return glist;
        }

        public Template GetTemplateById(int TemplateId)
        {
            return db.Templates.
                Where(x => x.TEMPLATE_ID == TemplateId).
                FirstOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using GreetingCardGenerator.Core;


namespace GreetingCardGenerator.Data
{
    public interface IAppData
    {
        Member Signup(Member member);
        Member Login(Member member);
        void SaveGreetingDraft(Greeting_Draft draft);
        void SaveTemplateDraft(Template_Draft draft);
        Sales AddNewPurchase(Sales sales);
        List<Sales> ViewAllSalesByUser(int userId);
        List<Greeting_Draft> ViewGreetingDraftsByUser(int userId);
        List<Template_Draft> ViewTemplateDraftByUser(int userId);

        //Admin
        Admin AdminLogin(Admin admin);
        void AddNewTemplate(Template template);
        List<Template> ViewAllTemplates();
        List<Member> ViewAllMembers();
        List<Greetings> ViewAllGreetings();
        void DeleteATemplate(int templateId);
        void DeleteAGreeting(int greetingId);
        void UpdateAGreeting(Greetings greeting);

        List<string> GetGreetingByLetter(char a);



    }
}

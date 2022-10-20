
using BusinessObject;
using DataAccess.Repository;

namespace test{
    class MainClass
    {
        public static void Main()
        {
            IMemberRepository repository = new MemberRepository();
            MemberObject member = repository.GetMemberByEmail("quan@gmail.com");
            if (member == null)
            {
                Console.WriteLine("member = null");

            }
            else
            {
                Console.WriteLine($"memberid: {member.MemberId}");
            }
        }
    }
}
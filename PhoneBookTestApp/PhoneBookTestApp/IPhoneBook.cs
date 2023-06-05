namespace PhoneBookTestApp
{
    public interface IPhoneBook
    {
        Person findPerson(string firstName, string lastName);
        void addPerson(Person newPerson);
    }
}
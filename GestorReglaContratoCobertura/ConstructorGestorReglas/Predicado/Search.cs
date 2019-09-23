using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace GestorReglaContratoCobertura.ConstructorGestorReglas.Predicado
{
    #region Search Class

    public class Search
    {
        private List<User> _users;
        public Search(List<User> users)
        {
            _users = users;
        }

        public List<User> Results { get; private set; }

        public List<User> For(string firstName = "", string lastName = "", string email = "", int? userId = null)
        {
            var result = new List<User>();

            //start building expression tree 

            //   Starting out with specifying the Entity/Model to be searched within the generic list.  
            //   In this case, we start with User list.
            var li = Expression.Parameter(typeof(User), "User");
            Expression where = null;

            if (!String.IsNullOrEmpty(firstName))
            {
                AndAlso(NameSearch(li, "First", firstName), ref where);
            }
            if (!String.IsNullOrEmpty(lastName))
            {
                AndAlso(NameSearch(li, "Last", lastName), ref where);
            }

            if (!String.IsNullOrEmpty(email))
            {
                AndAlso(EmailSearch(li, email), ref where);
            }
            if (userId.HasValue)
            {
                AndAlso(UserIdSearch(li, userId.Value), ref where);
            }

            if (where == null)
            {
                return _users;
            }

            var predicate = Expression.Lambda<Func<User, bool>>(where, new ParameterExpression[] { li }).Compile();

            return _users.Where(predicate).ToList();
        }

        private void AndAlso(Expression equals, ref Expression op)
        {
            if (op == null)
            {
                op = equals;
            }
            else
            {
                op = Expression.AndAlso(op, equals);
            }
        }

        /// <summary>
        /// Search first/last user name
        /// </summary>
        /// <param name="listOfNames"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private Expression NameSearch(Expression listOfNames, string propertyName, string value)
        {

            //  a. get expression for Name object within list
            var nameObjInList = Expression.Property(listOfNames, "Name");

            // b. get expression of property found in Name object
            var nameProperty = Expression.Property(nameObjInList, propertyName);

            // c. get MethodInfo of the StartWith method found in the String object
            var startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });

            // d. get expression that represents the name value to search 
            var nameSearch = Expression.Constant(value, typeof(string));

            // e. get the start with expression call
            var startWithCall = Expression.Call(nameProperty, startsWithMethod, new Expression[1] { nameSearch });

            // f. get expression that represents the value for the StartWith return upon executing
            var right = Expression.Constant(true, typeof(bool));

            // g. return final equals expression to help build predicate
            return Expression.Equal(startWithCall, right);

        }


        /// <summary>
        /// Search email within list of emails
        /// </summary>
        /// <param name="listOfNames"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private Expression EmailSearch(Expression listOfNames, string value)
        {
            //a. Create expression predicate. 
            Expression<Predicate<string>> emailPred = e => e.StartsWith(value);

            //b. Create expression property for User propery Emails list
            var ep = Expression.Property(listOfNames, "Emails");

            //c. Create constant value of return
            var isTrue = Expression.Constant(true, typeof(bool));

            //d. Get methodinfo for string List<string>.Exists(..) method
            var existsMethod = typeof(List<string>).GetMethod("Exists", new[] { typeof(Predicate<string>) });

            //e. Create expression call
            var existsCall = Expression.Call(ep, existsMethod, new Expression[1] { emailPred });

            //f. return comparison expression
            return Expression.Equal(existsCall, isTrue);

        }

        private Expression UserIdSearch(Expression listOfNames, int userId)
        {
            var userIdParam = Expression.Property(listOfNames, "UserId");
            var userIdValue = Expression.Constant(userId, typeof(int));

            return Expression.Equal(userIdParam, userIdValue);
        }
    }
    #endregion

    #region User Entity

    public class UserName
    {
        public string First { get; set; }

        public string Last { get; set; }
    }

    public class User
    {
        public User()
        {
            Emails = new List<String>();
            Name = new UserName();
        }

        public int UserId { get; set; }

        public UserName Name { get; set; }

        public List<string> Emails { get; set; }
    }

    #endregion
}

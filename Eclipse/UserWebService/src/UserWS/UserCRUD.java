package UserWS;

import java.io.File;
import java.io.Serializable;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.List;

import org.hibernate.HibernateError;
import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.Configuration;

//http://www.tutorialspoint.com/hibernate/hibernate_examples.htm

public class UserCRUD {
/*
	private static SessionFactory factory = getSessionFactory();
	private static String configurationString = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
"<!DOCTYPE hibernate-configuration PUBLIC" +
		"\"-//Hibernate/Hibernate Configuration DTD 3.0//EN\"" +
		"\"http://hibernate.sourceforge.net/hibernate-configuration-3.0.dtd\">" +
"<hibernate-configuration>"+
    "<session-factory>"+
        "<property name=\"hibernate.connection.driver_class\">com.mysql.jdbc.Driver</property>"+
        "<property name=\"hibernate.connection.password\">12345</property>"+
        "<property name=\"hibernate.connection.url\">jdbc:mysql://localhost:3306/packagetracking</property>"+
        "<property name=\"hibernate.connection.username\">cristiprg</property>"+
        "<property name=\"hibernate.default_schema\">packagetracking</property>"+
        "<property name=\"hibernate.dialect\">org.hibernate.dialect.MySQLDialect</property>"+     
        "<property name=\"show_sql\">true</property>"+
        "<property name=\"format_sql\">true</property>"+
        "<property name=\"use_sql_comments\">true</property>"+
        //"<mapping resource="User.hbm.xml"/>"+  
                 
    "</session-factory>"+
    "<hibernate-mapping>"+
    "<class name=\"UserWS.User\" table=\"user\" catalog=\"\">"+
        "<id name=\"id\" type=\"java.lang.Integer\">"+
            "<column name=\"id\" />"+
            "<generator class=\"identity\" />"+
        "</id>"+
        "<property name=\"name\" type=\"string\">"+
            "<column name=\"name\" length=\"50\" not-null=\"true\" />"+
        "</property>"+
        "<property name=\"username\" type=\"string\">"+
            "<column name=\"username\" length=\"50\" not-null=\"true\" />"+
        "</property>"+
        "<property name=\"password\" type=\"string\">"+
            "<column name=\"password\" length=\"50\" not-null=\"true\" />"+
        "</property>"+
        "<property name=\"type\" type=\"int\">"+
            "<column name=\"type\" not-null=\"true\" />"+
        "</property>"+
    "</class>"+
    "</hibernate-mapping>"+
"</hibernate-configuration>";
	
		
	private static SessionFactory getSessionFactory()
	{
		try
		{			
			//return new Configuration().configure().buildSessionFactory();
			//return new Configuration().configure(configurationString).buildSessionFactory();
			return null;
		}
		catch (Exception e)
		{
			System.err.println("Failed to create sessionFactory "+ e);
			throw new ExceptionInInitializerError(e);
		}
	}*/
	
	public int createUser(User _user)
	{
		 Connection con = null;
	        PreparedStatement st = null;
	        ResultSet rs = null;

	        String url = "jdbc:mysql://localhost:3306/packagetracking";
	        String user = "cristiprg";
	        String password = "12345";

	        try {
	            con = DriverManager.getConnection(url, user, password);
	            st = con.prepareStatement("INSERT INTO `user` (name, username, password, type) VALUES (?, ?, ?, ?) ", Statement.RETURN_GENERATED_KEYS);
	            st.setString(1, _user.getName());
	            st.setString(2, _user.getUsername());
	            st.setString(3, _user.getPassword());
	            st.setInt(4, _user.getType() );
	            int affectedRows = st.executeUpdate();

	            if(affectedRows == 0)
	            {
	            	System.err.println("Creating user failed, no rows affected!");
	            	return -1;
	            }
	            
	            rs = st.getGeneratedKeys();
	            if(rs.next())
	            {
	            	return rs.getInt(1);
	            }

	        } catch (SQLException ex) {
	           System.err.println("COAIE!!!" + ex.getMessage());
	           
	        }
	        return -2;
	}
	
	public User getUser(int user_id)
	{
		Connection con = null;
        Statement st = null;
        ResultSet rs = null;

        String url = "jdbc:mysql://localhost:3306/packagetracking";
        String user = "cristiprg";
        String password = "12345";

        try {
            con = DriverManager.getConnection(url, user, password);
            st = con.createStatement();            
            rs = st.executeQuery("SELECT * FROM `user` WHERE `id`="+user_id);
            
            if(rs.next())
            {
            	return new User(rs.getInt(1), rs.getString(2), rs.getString(3), 
            			rs.getString(4), rs.getInt(5));
            }
            
            throw new SQLException("ceva nu e bine");

        } catch (SQLException ex) {
           System.err.println("COAIE!!!" + ex.getMessage());
           
        }
        return null;
	}
	
	public int getUser(String _username, String _password)
	{
		Connection con = null;
        Statement st = null;
        ResultSet rs = null;

        String url = "jdbc:mysql://localhost:3306/packagetracking";
        String user = "cristiprg";
        String password = "12345";
        
        
        try {
        	Class.forName("com.mysql.jdbc.Driver");
            con = DriverManager.getConnection(url, user, password);
            st = con.createStatement();  
            String query = "SELECT * FROM `user` WHERE `username`='"+_username+
            		"' AND `password`='" + _password + "'";
            rs = st.executeQuery( query );
            if(rs.next())
            {
            	//return new User(rs.getInt(1), rs.getString(2), rs.getString(3), 
            	//		rs.getString(4), rs.getInt(5));
            	return rs.getInt(1);
            }
            
            return -1;

        } catch (SQLException ex) {
           System.err.println("COAIE!!!" + ex.getMessage());
           
        } catch (ClassNotFoundException e) {
			System.err.println("Class Not Found Ex: " + e.getMessage());
			//e.printStackTrace();
		}
        return -2;
	}
	
/*
	public int createUser(User user)
	{
		Session session = factory.openSession();
		Transaction tx = null;
		int user_id = 0;
		try
		{
			tx = session.beginTransaction();
			user_id =  (Integer)session.save(user);
			tx.commit();
		}
		catch (HibernateException e)
		{
			if(tx != null)
				tx.rollback();
			e.printStackTrace();
		}
		finally
		{
			session.close();
		}
		return user_id;
	}
	
	public User getUser(int user_id)
	{
		Session session = factory.openSession();
		try
		{
			User user = (User)session.get(User.class, user_id);
			return user;
		}
		catch(HibernateException e)
		{
			e.printStackTrace();
		}
		finally
		{
			session.close();
		}
		return null;
	}
	

	public List<User> getAllUsers()
	{
		Session session  = factory.openSession();
		Transaction tx = null;
		try
		{
			tx = session.beginTransaction();
			List<User> users = session.createQuery("From User").list();
			tx.commit();
			return users;
		}
		catch (HibernateException e)
		{
			if(tx != null)
				tx.rollback();
			e.printStackTrace();
		}
		finally
		{
			session.close();
		}
		return null;
	}

	public void deleteUser(int user_id)
	{
		Session session = factory.openSession();
		Transaction tx = null;
		try
		{
			tx = session.beginTransaction();
			User user = (User)session.get(User.class, user_id);
			session.delete(user);
			tx.commit();
		}
		catch(HibernateException e)
		{
			if(tx != null)
				tx.rollback();
			e.printStackTrace();
		}
		finally
		{
			session.close();
		}
	}
	
	public void deleteUser(User user)
	{
		deleteUser(user.getId());
	}
	*/
}

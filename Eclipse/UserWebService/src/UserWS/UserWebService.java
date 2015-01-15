package UserWS;

import java.util.List;

import javax.jws.WebMethod;
import javax.jws.WebService;

@WebService
public class UserWebService {

	final static UserCRUD userCRUD = new UserCRUD();
	
	public int add(int a, int b)
	{
		return a+b;
	}
	
	
	@WebMethod
	public User findUserById(int id)
	{
		return userCRUD.getUser(id);
	}
	
	public int findUserByUsernameAndPassword(String username, String password)
	{
		return userCRUD.getUser(username, password);
	}
	

	@WebMethod
	public int createUser(String name, String username, String password, int type)
	{
		return userCRUD.createUser(new User(name, username, password, type));
	}
	
/*	
	@WebMethod
	public void DeleteUserById(int id)
	{
		userCRUD.deleteUser(id);
	}*/
	/*
	@WebMethod
	public User[] GetAllUsers()
	{
		return (User[]) userCRUD.getAllUsers().toArray();
	}
	*/
}

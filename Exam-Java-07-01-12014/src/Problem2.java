import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;


public class Problem2 {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		String text = sc.nextLine();
		 ArrayList<String> allBombs = new ArrayList<String>();
		 Matcher m = Pattern.compile("\\|[^\\n]*?\\|")
		     .matcher(text);
		 while (m.find()) {
		   allBombs.add(m.group());
		 }
		// System.out.println(allBombs.size());
		 for(int i = 0; i < allBombs.size(); i++){
			 if(allBombs.get(i).length() > 102){
				 System.out.println(allBombs.get(i).length());
				 continue;
			 }
			 int bombPosition = 0;
			 bombPosition = text.indexOf(allBombs.get(i));
			 String bombLetters = allBombs.get(i).substring(0, allBombs.get(i).length()-2);
			 bombLetters = allBombs.get(i).substring(1, allBombs.get(i).length()-1);
			 int letterSum = 0;
			 for(int j = 0; j < bombLetters.length(); j++){
				 letterSum += bombLetters.charAt(j);
			 }
			 letterSum  = letterSum % 10;
			 int bombLength = allBombs.get(i).length();
			 int expFirstPos = bombPosition - letterSum; 
			 int expLastPos = bombPosition+ bombLength + letterSum;
			 if(expFirstPos < 0){
				 expFirstPos = 0;
			 }
			 if (expLastPos > text.length()){
				 expLastPos = text.length();
			 }
			 int expLength = expLastPos - expFirstPos;				 
		
			 String dots= "";
			 for(int k = 0; k < expLength; k++){
				 dots += '.';
			 }
			 text = text.replace(text.subSequence(expFirstPos, expFirstPos+expLength), dots);

		 }
		 System.out.println(text);
		 sc.close();
	}


}


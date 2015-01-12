import java.util.ArrayList;
import java.util.Scanner;
import java.util.TreeSet;

public class Problem1 {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Scanner sc = new Scanner(System.in);
		int n = Integer.parseInt(sc.nextLine());
		//Integer firstNum = Integer.MIN_VALUE;
		ArrayList<TreeSet<Integer>> rows = new ArrayList<TreeSet<Integer>>();
		for (int i = 0; i < n; i++) {
			TreeSet<Integer> rowValues = new TreeSet<Integer>();
			String[] row = sc.nextLine().trim().split(" +");
			for (int j = 0; j < row.length; j++) {
				row[j] = row[j].trim();
				//System.out.println(Integer.parseInt(row[j])+"L");
				rowValues.add(Integer.parseInt(row[j]));
//				if (i == 0 && j == 0) {
//					firstNum = Integer.parseInt(row[j]);
//				}
			}
			rows.add(rowValues);
		}
		String output = "";
		Integer currentClosest = Integer.MIN_VALUE;
		//Integer prevFound = Integer.MIN_VALUE;
		Boolean isFound = false;
		for (int i = 0; i < rows.size(); i++) {
			for (Integer c : rows.get(i)) {
				if (c > currentClosest && !isFound) {
					currentClosest = c;
					isFound = true;
				}
			}
			if(!isFound){
				currentClosest++;
			}
			if(isFound){
				output += currentClosest+", ";
			}
			isFound = false;
		}
		System.out.println(output.substring(0, output.length()-2));
	}

}

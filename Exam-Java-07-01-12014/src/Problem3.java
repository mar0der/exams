import java.util.ArrayList;
import java.util.Scanner;
import java.util.TreeSet;

public class Problem3 {

	public static void main(String[] args) {
		Scanner sc = new Scanner(System.in);
		int n = Integer.parseInt(sc.nextLine());
		ArrayList<ArrayList<String>> rows = new ArrayList<ArrayList<String>>();
		for (int i = 0; i < n; i++) {
			ArrayList<String> rowValues = new ArrayList<String>();
			String[] row = sc.nextLine().trim().split("");
			for (int j = 0; j < row.length; j++) {
				rowValues.add(row[j]);
			}
			rows.add(rowValues);
		}
		boolean moved = true;
		while (moved) {
			moved = false;
			int left = 0;
			int right = rows.get(0).size() - 1;
			int top = 0;
			int bottom = rows.size() - 1;
			for (int i = 0; i < rows.size(); i++) {
				for (int j = 0; j < rows.get(i).size(); j++) {
					int item = (int) rows.get(i).get(j).charAt(0);

					//
					// int itemTop = (int) rows.get(i - 1).get(j).charAt(0);
					// int itemBottom = (int) rows.get(i + 1).get(j).charAt(0);
					if (item == 60) {
						if (j != 0) {
							int itemLeft = (int) rows.get(i).get(j - 1)
									.charAt(0);
							if (itemLeft != 62 && itemLeft != 94
									&& itemLeft != 118 && itemLeft != 60) {
								rows.get(i).set(j - 1, ((char) 60) + "");
								rows.get(i).set(j, ((char) 111) + "");
								moved = true;
							}
						}

					} else if (item == 62) {
						if (j < right) {
							int itemRight = (int) rows.get(i).get(j + 1)
									.charAt(0);
							if (itemRight != 60 && itemRight != 94
									&& itemRight != 118 && itemRight != 62) {
								rows.get(i).set(j + 1, ((char) 62) + "");
								rows.get(i).set(j, ((char) 111) + "");
								moved = true;
							}
						}
					} else if (item == 94) {
						if (i != 0) {
							int itemTop = (int) rows.get(i - 1).get(j)
									.charAt(0);
							if (itemTop != 60 && itemTop != 62
									&& itemTop != 118 && itemTop != 94) {
								rows.get(i - 1).set(j, ((char) 94) + "");
								rows.get(i).set(j, ((char) 111) + "");
								moved = true;
							}
						}
					} else if (item == 118) {
						if (i < bottom) {
							int itemBottom = (int) rows.get(i + 1).get(j)
									.charAt(0);
							if (itemBottom != 60 && itemBottom != 62
									&& itemBottom != 94 && itemBottom != 118) {
								rows.get(i + 1).set(j, ((char) 118) + "");
								rows.get(i).set(j, ((char) 111) + "");
								moved = true;
							}
						}
					}
				}
			}
		}
		for (int i = 0; i < rows.size(); i++) {
			for (int j = 0; j < rows.get(i).size(); j++) {
				System.out.print(rows.get(i).get(j));
			}
			System.out.println();
		}

	}
}

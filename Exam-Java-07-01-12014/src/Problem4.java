import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Problem4 {

	public static void main(String[] args) {
		Scanner input = new Scanner(System.in);
		int n = Integer.parseInt(input.nextLine());

		String[] inputs = new String[n];
		Map<String, Map<String, Integer>> studentsMap = new TreeMap<>();
		Map<String, Map<String, Integer>> subjectCountsMap = new TreeMap<>();

		for (int i = 0; i < n; i++) {
			String[] splitedStrings = input.nextLine().split(" ");
			String name = splitedStrings[0] + ' ' + splitedStrings[1];
			String subject = splitedStrings[2];
			int grade = Integer.parseInt(splitedStrings[3]);

			if (studentsMap.get(name) == null) {
				studentsMap.put(name, new TreeMap<>());
				studentsMap.get(name).put(subject, grade);
			} else {
				if (studentsMap.get(name).get(subject) == null) {
					studentsMap.get(name).put(subject, grade);
				} else {
					int oldAmount = studentsMap.get(name).get(subject);
					studentsMap.get(name).put(subject, (grade + oldAmount));
				}
			}
			if (subjectCountsMap.get(name) == null) {
				subjectCountsMap.put(name, new TreeMap<>());
				subjectCountsMap.get(name).put(subject, 1);
			} else {
				if (subjectCountsMap.get(name).get(subject) == null) {
					subjectCountsMap.get(name).put(subject, 1);
				} else {
					int oldAmount = subjectCountsMap.get(name).get(subject);
					subjectCountsMap.get(name).put(subject, (oldAmount+1));
				}
			}
		}

		for (String key : studentsMap.keySet()) {
			String result = key + ": [";
			Map<String, Integer> innerMap = studentsMap.get(key);
			Map<String, Integer> subjectCount = subjectCountsMap.get(key);
			for (String innerKey : innerMap.keySet()) {
				float averageGrade = (float) innerMap.get(innerKey) / subjectCount.get(innerKey);
				result += String.format("%s - %.2f, ", innerKey, averageGrade);

			}
			System.out.println(result.substring(0, result.length() - 2)+']');
		}

	}

}

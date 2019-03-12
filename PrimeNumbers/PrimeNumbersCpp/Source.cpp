#include<iostream>
#include<vector>

int main()
{
	int i = 6;
	int j = 5;
	std::vector<int> nums;
	bool sch = false;
	while (true)
	{
		for (int num : nums)
		{
			if (num*num > j)
			{
				break;
			}
			if (j % num == 0)
			{
				goto noprime;
			}
		}
		nums.push_back(j);
		std::cout << nums.size() + 1 << " " << j << "\n";
	noprime:
		if (sch)
		{
			j = i + 1;
			i += 6;
			sch = false;
		}
		else
		{
			j = i - 1;
			sch = true;
		}
	}
	return 0;
}
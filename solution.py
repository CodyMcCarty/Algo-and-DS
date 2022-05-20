def search(nums: list[int], target: int) -> int:
    lowI = 0
    highI = len(nums)

    while lowI < highI:
        midI = (lowI + highI) // 2
        midNum = nums[midI]
        if midNum < target:
            lowI = midI + 1
        else:
            highI = midI
    return lowI
    #     if midNum == target:
    #         return midI
    #     if midNum < target:
    #         lowI = midI + 1
    #     if midNum > target:
    #         highI = midI
    # return -1

print(search([-1,0,3,5,9,12], 9))
print(search([-1,0,3,5,9,12,14,16,20,23,45,53,55,61,82], 82))
print(search([-1,0,3,5,9,12,14,16,20,23,45,53,55,61,82,86], 86))
print(search([-1,0,3,5,9,12,14,16,20,23,45,53,55,61,82], 555))
print(search([-1,0,3,5,9,12,14,16,20,23,45,53,55,61,82], -5))

# def search(a, b):
#     return b

# print(search([2,6,74], 9))
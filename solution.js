// The global variable
/* TODO: list for JS
[] make solution.test.js
*/

/**
 *Write your own Array.prototype.myFilter(), which should behave exactly
 *like Array.prototype.filter(). You should not use the built-in filter
 *method.  The Array instance can be accessed in the myFilter method
 *using this.
 */
const myFilter = () => {
  let s = [23, 65, 98, 5];

  Array.prototype.myFilter = function (callback) {
    let newArray = [];
    this.forEach((e) => {
      if (callback(e)) newArray.push(e);
    });
    return newArray;
  };

  let new_s = s.myFilter(function (item) {
    return item % 2 === 1;
  });
  return "actual: ", new_s, "expected: ", [23, 65, 5];
};

console.log(myFilter());

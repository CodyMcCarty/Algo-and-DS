// The global variable
/* TODO: list for JS
[] make solution.test.js
[] remove console log ect now that we have proper testing
[] Do I have linting?
[] obj of functions?
*/

/**
 * simple Curry function
 * @param {Curry} x first of three a currying function
 * @returns a function or 3 things added together
 */
const add = (x) => {
  return (y) => (z) => x + y + z;
};

// console.log(add(10)(20)(30), "\n60 \n");
// console.log(add(11)(22)(33), "\n66 \n");
// console.log(add(5)(5), "\nFunction \n");
// let addTen = add(5)(5);
// console.log(addTen(20), "\n30 \n");
// console.log(addTen(40), "\n50 \n");

/**
 * Make a function that looks through a collection and returns an array
 * of all objects that have matching name and value pairs (second argument).
 * Each name and value pair of the source object has to be present in the
 * object from the collection if it is to be included in the returned array.
 * @param {JSON} collection array of objects
 * @param {Object} source what to look for
 * @returns
 */
function whatIsInAName(collection, source) {
  const sourceKeys = Object.keys(source);

  return collection.filter((obj) =>
    sourceKeys.every(
      (key) => obj.hasOwnProperty(key) && obj[key] === source[key]
    )
  );
}

// console.log(
//   "t1",
//   whatIsInAName(
//     [{ apple: 1, bat: 2 }, { apple: 1 }, { apple: 1, bat: 2, cookie: 2 }],
//     { apple: 1, cookie: 2 }
//   ),
//   "\n&e [ { apple: 1, bat: 2, cookie: 2 } ]"
// );

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

// console.log(myFilter());

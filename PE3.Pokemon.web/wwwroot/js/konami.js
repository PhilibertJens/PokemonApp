/* jshint esversion: 6 */
//#region konamicode
const pressed = [];
let up = 38,down = 40,left = 37,right = 39,A = 65,B = 66;
const secretCode = [up,up,down,down,left,right,left,right,A,B];
window.addEventListener('keyup', (e) => {
  pressed.push(e.keyCode);
  pressed.splice(-secretCode.length - 1, pressed.length - secretCode.length);
  if (pressed.join('').includes(secretCode.join(''))) {
    console.log('DING DING!');
    //TODO: do something here
  }
  console.log(pressed);
});
//#endregion konamicode

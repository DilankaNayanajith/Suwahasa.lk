export class Validations {
  public static validateContact(data: string = ""): boolean {
    if (data.length == 10) {
      return this.isOnlyNumbers(data);
    } else return false;
  }

  public static validateEmail(data: string = ""): boolean {
    let regex = new RegExp(
      /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
    );
    return regex.test(data.toLowerCase());
  }

  public static validatePostalCodes(data: string = ""): boolean {
    if (data.length == 5) {
      return this.isOnlyNumbers(data);
    } else return false;
  }

  public static validateString(data: string = ""): boolean {
    if (data.length >= 3) return true;
    else return false;
  }

  public static validateNationalId(data: string = ""): boolean {
    if (data.length == 10) {
      let numbers = data.substr(0, 9);
      let letter = data.substr(9, 9).toLowerCase();
      console.log("numbers: ", numbers, "letter: ", letter);
      if (this.isOnlyNumbers(numbers) && (letter == "x" || letter == "v")) {
        return true;
      } else {
        return false;
      }
    } else return false;
  }

  public static isOnlyNumbers(data: string = ""): boolean {
    let isnum = /^\d+$/.test(data);
    return isnum;
  }

  public static isOnlyLetters(data: string = ""): boolean {
    return /^[a-zA-Z]+$/.test(data);
  }

  public static validateVehicleNumber(data: string = ""): boolean {
    if (data.length >= 7) {
      let last4Chars = data.substr(data.length - 4, data.length);
      if (this.isOnlyNumbers(last4Chars)){
        let first2Chars = data.substr(0, 2);
        let first3Chars = data.substr(0, 3);
        if (this.isOnlyLetters(first3Chars)){
          return true;
        }else{
          if (this.isOnlyLetters(first2Chars) || this.isOnlyNumbers(first2Chars)){
            return true;
          }else return false;
        }
      }else return false;
    } else return false;
  }

  public static generateInvalidText(data: string[] = []): string {
    let text = "";
    for (let i = 0; i < data.length; i++) {
      if (i == data.length - 1) {
        if (data.length >= 2) {
          text += `and ${data[i]} `;
        } else {
          text += `${data[i]} `;
        }
      } else {
        text += `${data[i]}, `;
      }
    }
    if (data.length >= 2) {
      text += "fields are invalid, please enter valid details and try again.";
    } else {
      text += "field is invalid, please enter valid details and try again.";
    }

    return text;
  }
}

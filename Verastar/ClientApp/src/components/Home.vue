<template>
    <div class="hello">
        <h1>{{ msg }}</h1>
        <img src="../assets/logo.png" />
        <p>
            Welcome to Verastar mobile ordering app, please enter your mobile number to continue:
        </p>
        <div class="container pt-4">
            <div class="form-inline justify-content-center">

                <div class="form-group">
                    <label for="mobilenumber" class="mr-2">Mobile Number:</label>
                    <input type="text" class="form-control mr-2" id="mobilenumber" value="07712345678">
                </div>
                <button type="submit" class="btn btn-primary" @click="$router.push('MobilePhones')">Continue</button>

            </div>
        </div>
    </div>
</template>

<script>
export default {
  name: 'Home',
  props: {
    msg: String
        }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>

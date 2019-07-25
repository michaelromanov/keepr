<template>
    <div>
        <form @submit.prevent="createKeep()">
            <input type="text" v-model="newkeep.name" placeholder="name">
            <input type="text" v-model="newkeep.description" placeholder="description">
            <input type="text" v-model="newkeep.img" placeholder="url">
            <button class="btn btn-primary" type="submit">Create New Friend</button>
        </form>
    </div>
</template>

<script>
export default {
name: "createkeep", 
data() {
    return {
        newkeep: {
            name: '', 
            decription: '', 
            img: ''
        }
    }
}, 
methods: {
    createKeep(){
        this.$store.dispatch("createKeep", this.newkeep)
    }
}
}
</script>

<style scoped>
form {
  display: flex;
}
input[type="text"] {
  flex: 10;
  padding: 10px;
  border: 1px solid #41b883;
  outline: 0;
}
input[type="submit"] {
  flex: 2;
  background: #41b883;
  color: #fff;
  border: 1px #41b883 solid;
  cursor: pointer;
}
</style>